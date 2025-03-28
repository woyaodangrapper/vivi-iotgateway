using Vivi.Dcs.Contracts.DTOs;

namespace Vivi.Dcs.Contracts.Services;

public interface ISmartDeviceAppService : IAppService
{
    Task<AppSrvResult<List<SmartDeviceDTO>>> GetListAsync();
}