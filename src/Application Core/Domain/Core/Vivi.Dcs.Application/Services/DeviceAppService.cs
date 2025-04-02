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

    public async Task<AppSrvResult<long>> CreateAsync(DeviceRequestDto input)
    {
        var deviceEntity = _mapper.Map<DeviceEntity>(input);
        return await _deviceRepository.InsertAsync(deviceEntity);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _deviceRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<DeviceDto>> GetPagedAsync(DeviceQueryDto input)
    {
        var search = new QueryDeviceCommand()
        {
            name = input.Name,
            pageIndex = input.pageIndex,
            pageSize = input.pageSize,
        };

        var whereExpression = ExpressionCreator
       .New<DeviceEntity>()
       .AndIf(!string.IsNullOrWhiteSpace(search.name), x => x.Name.Contains(search!.name!))
        // .NotDeleted();
        ;
        return await _deviceRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDto { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<DeviceDto>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(DeviceRequestDto input)
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