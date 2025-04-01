using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class SensorCapabilityMapAppService : AbstractAppService, ISmartDeviceAppService
{
    private readonly IEfRepository<SensorCapabilityMapEntity> _sensorCapabilityRepository;
    private readonly IObjectMapper _mapper;

    public SensorCapabilityMapAppService(ILogger<SensorCapabilityMapAppService> logger,
         IEfRepository<SensorCapabilityMapEntity> sensorCapabilityRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _sensorCapabilityRepository = sensorCapabilityRepository;
    }

    public async Task<AppSrvResult<long>> CreateAsync(DeviceRequestDto input)
    {
        var sensorCapabilityMapEntity = _mapper.Map<SensorCapabilityMapEntity>(input);
        return await _sensorCapabilityRepository.InsertAsync(sensorCapabilityMapEntity);
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
       .New<SensorCapabilityMapEntity>()
        // .NotDeleted();
        ;

        return await _sensorCapabilityRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDto { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<DeviceDto>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(DeviceRequestDto input)
    {
        var device = _mapper.Map<SensorCapabilityMapEntity>(input);
        var rwoAdd = await _sensorCapabilityRepository.UpdateAsync(device, UpdatingProps<SensorCapabilityMapEntity>(x =>
            x.Equals(device)
         ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}