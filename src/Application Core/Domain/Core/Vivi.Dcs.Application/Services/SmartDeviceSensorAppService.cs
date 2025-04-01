using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class SmartDeviceSensorAppService : AbstractAppService, ISmartDeviceAppService
{
    private readonly IEfRepository<SmartDeviceSensorEntity> _smartDeviceSensorRepository;
    private readonly IObjectMapper _mapper;

    public SmartDeviceSensorAppService(ILogger<SmartDeviceSensorAppService> logger,
         IEfRepository<SmartDeviceSensorEntity> smartDeviceSensorRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _smartDeviceSensorRepository = smartDeviceSensorRepository;
    }

    public async Task<AppSrvResult<long>> CreateAsync(DeviceRequestDto input)
    {
        var smartDeviceSensorEntity = _mapper.Map<SmartDeviceSensorEntity>(input);
        return await _smartDeviceSensorRepository.InsertAsync(smartDeviceSensorEntity);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _smartDeviceSensorRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<DeviceDto>> GetPagedAsync(DeviceQueryDto? input)
    {
        var search = new QueryDeviceCommand()
        {
        };

        var whereExpression = ExpressionCreator
       .New<SmartDeviceSensorEntity>()
        // .NotDeleted();
        ;

        return await _smartDeviceSensorRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDto { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<DeviceDto>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(DeviceRequestDto input)
    {
        var device = _mapper.Map<SmartDeviceSensorEntity>(input);
        var rwoAdd = await _smartDeviceSensorRepository.UpdateAsync(device, UpdatingProps<SmartDeviceSensorEntity>(x =>
         x.Equals(device)
            ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}