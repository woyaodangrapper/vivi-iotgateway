using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class DeviceUnitAppService : AbstractAppService, IDeviceUnitAppService
{
    private readonly IEfRepository<DeviceUnitEntity> _deviceUnitRepository;
    private readonly IObjectMapper _mapper;

    public DeviceUnitAppService(ILogger<DeviceUnitAppService> logger,
         IEfRepository<DeviceUnitEntity> deviceUnitRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _deviceUnitRepository = deviceUnitRepository;
    }

    public async Task<AppSrvResult<IdDTO>> CreateAsync(DeviceUnitRequestDTO input)
    {
        var entity = _mapper.Map<DeviceUnitEntity>(input);
        await _deviceUnitRepository.InsertAsync(entity);
        return new IdDTO(entity.Id);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _deviceUnitRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<DeviceUnitDTO>> GetPagedAsync(DeviceUnitQueryDTO input)
    {
        var search = new QueryDeviceUnitCommand()
        {
            DeviceId = input.DeviceId,
            UnitType = input.UnitType,
            InstallationPosition = input.InstallationPosition,
            pageIndex = input.pageIndex,
            pageSize = input.pageSize,
        };

        var whereExpression = ExpressionCreator
       .New<DeviceUnitEntity>()
        // .NotDeleted();
        ;

        return await _deviceUnitRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDTO { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<DeviceUnitDTO>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(DeviceUnitRequestDTO input)
    {
        var device = _mapper.Map<DeviceUnitEntity>(input);
        var rwoAdd = await _deviceUnitRepository.UpdateAsync(device, UpdatingProps<DeviceUnitEntity>(x =>
         x.Equals(device)
            ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}