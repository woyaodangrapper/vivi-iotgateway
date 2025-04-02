using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class DeviceUnitAppService : AbstractAppService, IDeviceUnitAppService
{
    private readonly IEfRepository<DeviceUnitEntity> _deviceUnitSensorRepository;
    private readonly IObjectMapper _mapper;

    public DeviceUnitAppService(ILogger<DeviceUnitAppService> logger,
         IEfRepository<DeviceUnitEntity> deviceUnitSensorRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _deviceUnitSensorRepository = deviceUnitSensorRepository;
    }

    public async Task<AppSrvResult<long>> CreateAsync(DeviceUnitRequestDto input)
    {
        var deviceUnitSensorEntity = _mapper.Map<DeviceUnitEntity>(input);
        return await _deviceUnitSensorRepository.InsertAsync(deviceUnitSensorEntity);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _deviceUnitSensorRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<DeviceUnitDto>> GetPagedAsync(DeviceUnitQueryDto input)
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

        return await _deviceUnitSensorRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDto { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<DeviceUnitDto>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(DeviceUnitRequestDto input)
    {
        var device = _mapper.Map<DeviceUnitEntity>(input);
        var rwoAdd = await _deviceUnitSensorRepository.UpdateAsync(device, UpdatingProps<DeviceUnitEntity>(x =>
         x.Equals(device)
            ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}