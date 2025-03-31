using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using Vivi.Dcs.Contracts.DTOs.SmartDevice;


namespace Vivi.Dcs.Application.Implements;

public class SmartDeviceAppService : AbstractAppService, ISmartDeviceAppService
{
    private readonly IEfRepository<SmartDeviceEntity> _deviceEntityRepository;
    private readonly IObjectMapper _mapper;

    public SmartDeviceAppService(ILogger<SmartDeviceAppService> logger,
         IEfRepository<SmartDeviceEntity> deviceEntityRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _deviceEntityRepository = deviceEntityRepository;
    }

    public async Task<AppSrvResult<long>> CreateAsync(DeviceRequestDto input)
    {
        var smartDeviceEntity = _mapper.Map<SmartDeviceEntity>(input);
        return await _deviceEntityRepository.InsertAsync(smartDeviceEntity);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _deviceEntityRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<AppSrvResult<List<DeviceDto>>> GetListAsync()
    {
        var devices = await _deviceEntityRepository.GetAll().ToListAsync();
        return _mapper.Map<List<DeviceDto>>(devices);
    }

    public async Task<AppSrvResult> UpdateAsync(Guid id, DeviceRequestDto input)
    {

        var device = _mapper.Map<SmartDeviceEntity>(input);
        var rows = await _deviceEntityRepository.UpdateAsync(device, UpdatingProps<SmartDeviceEntity>(x =>
            id,
            x => x.Name
         ));
        if (rows is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}

