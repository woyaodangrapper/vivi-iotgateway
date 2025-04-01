using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class SensorDataAppService : AbstractAppService, ISmartDeviceAppService
{
    private readonly IEfRepository<SensorDataEntity> _sensorDataRepository;
    private readonly IObjectMapper _mapper;

    public SensorDataAppService(ILogger<SensorDataAppService> logger,
         IEfRepository<SensorDataEntity> sensorDataRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _sensorDataRepository = sensorDataRepository;
    }

    public async Task<AppSrvResult<long>> CreateAsync(DeviceRequestDto input)
    {
        var sensorDataEntity = _mapper.Map<SensorDataEntity>(input);
        return await _sensorDataRepository.InsertAsync(sensorDataEntity);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _sensorDataRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<DeviceDto>> GetPagedAsync(DeviceQueryDto? input)
    {
        var search = new QueryDeviceCommand()
        {
        };

        var whereExpression = ExpressionCreator
       .New<SensorDataEntity>()
        // .NotDeleted();
        ;

        return await _sensorDataRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDto { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<DeviceDto>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(DeviceRequestDto input)
    {
        var device = _mapper.Map<SensorDataEntity>(input);
        var rwoAdd = await _sensorDataRepository.UpdateAsync(device, UpdatingProps<SensorDataEntity>(x =>
         x.Equals(device)
         ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}