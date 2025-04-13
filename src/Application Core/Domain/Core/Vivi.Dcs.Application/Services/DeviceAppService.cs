using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class DeviceAppService : AbstractAppService, IDeviceAppService
{
    private readonly IEfRepository<DeviceEntity> _deviceRepository;
    private readonly IObjectMapper _mapper;

    public DeviceAppService(ILogger<DeviceAppService> logger,
         IEfRepository<DeviceEntity> deviceRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _deviceRepository = deviceRepository;
    }

    public async Task<AppSrvResult<IdDTO>> CreateAsync(DeviceRequestDTO input)
    {
        var entity = _mapper.Map<DeviceEntity>(input);
        await _deviceRepository.InsertAsync(entity);
        return new IdDTO(entity.Id);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _deviceRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<DeviceDTO>> GetPagedAsync(DeviceQueryDTO input)
    {
        var search = new QueryDeviceCommand()
        {
            name = input.Name,
            model = input.Model,
            number = input.Number,
            status = input.Status,
            pageIndex = input.pageIndex,
            pageSize = input.pageSize,
        };

        var whereExpression = ExpressionCreator
       .New<DeviceEntity>()
       .AndIf(!string.IsNullOrWhiteSpace(search.name), x => x.Name.Contains(search!.name!))
       .AndIf(search.model.HasValue, x => x.Model == search!.model)
       .AndIf(!string.IsNullOrWhiteSpace(search.number), x => x.Number != null && x.Number.Contains(search!.number!))
       .AndIf(search.status.HasValue, x => x.Status == search!.status)
        // .NotDeleted();
        ;
        return await _deviceRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDTO { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<DeviceDTO>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(DeviceRequestDTO input)
    {
        var device = _mapper.Map<DeviceEntity>(input);
        var rwoAdd = await _deviceRepository.UpdateAsync(device, UpdatingProps<DeviceEntity>(x =>
            x.Name,
            x => x.Model,
            x => x.Manufacturer,
            x => x.InstallationLocation
         ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}