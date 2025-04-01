using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class SmartDeviceAppService : AbstractAppService, ISmartDeviceAppService
{
    private readonly IEfRepository<SmartDeviceEntity> _smartDeviceRepository;
    private readonly IObjectMapper _mapper;

    public SmartDeviceAppService(ILogger<SmartDeviceAppService> logger,
         IEfRepository<SmartDeviceEntity> smartDeviceRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _smartDeviceRepository = smartDeviceRepository;
    }

    public async Task<AppSrvResult<long>> CreateAsync(DeviceRequestDto input)
    {
        var smartDeviceEntity = _mapper.Map<SmartDeviceEntity>(input);
        return await _smartDeviceRepository.InsertAsync(smartDeviceEntity);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _smartDeviceRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<DeviceDto>> GetPagedAsync(DeviceQueryDto? input)
    {
        var search = new QueryDeviceCommand()
        {
        };

        var whereExpression = ExpressionCreator
       .New<SmartDeviceEntity>()
        // .NotDeleted();
        ;
        return await _smartDeviceRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDto { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<DeviceDto>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(DeviceRequestDto input)
    {
        var device = _mapper.Map<SmartDeviceEntity>(input);
        var rwoAdd = await _smartDeviceRepository.UpdateAsync(device, UpdatingProps<SmartDeviceEntity>(x =>
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