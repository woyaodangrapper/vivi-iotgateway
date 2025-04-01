using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class SensorCapabilityAppService : AbstractAppService, ISmartDeviceAppService
{
    private readonly IEfRepository<SensorCapabilityEntity> _sensorCapabilityRepository;
    private readonly IObjectMapper _mapper;

    public SensorCapabilityAppService(ILogger<SensorCapabilityAppService> logger,
         IEfRepository<SensorCapabilityEntity> sensorCapabilityRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _sensorCapabilityRepository = sensorCapabilityRepository;
    }

    public async Task<AppSrvResult<long>> CreateAsync(DeviceRequestDto input)
    {
        var sensorCapabilityEntity = _mapper.Map<SensorCapabilityEntity>(input);
        return await _sensorCapabilityRepository.InsertAsync(sensorCapabilityEntity);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _sensorCapabilityRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<DeviceDto>> GetPagedAsync(DeviceQueryDto? input)
    {
        var search = new QueryDeviceCommand()
        {
        };

        var whereExpression = ExpressionCreator
       .New<SensorCapabilityEntity>()
        // .NotDeleted();
        ;

        return await _sensorCapabilityRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDto { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<DeviceDto>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(DeviceRequestDto input)
    {
        var device = _mapper.Map<SensorCapabilityEntity>(input);
        var rwoAdd = await _sensorCapabilityRepository.UpdateAsync(device, UpdatingProps<SensorCapabilityEntity>(x =>
            x.Name
         ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}