using Vivi.Dcs.Contracts.DTOs;
using Vivi.Dcs.Contracts.Services;

namespace Vivi.Dcs.Application.Services;

public class SmartDeviceAppService : AbstractAppService, ISmartDeviceAppService
{
    public async Task<AppSrvResult<List<SmartDeviceDTO>>> GetListAsync()
    {
        return await Task.FromResult(new List<SmartDeviceDTO>() { new () {
        } });
    }
}