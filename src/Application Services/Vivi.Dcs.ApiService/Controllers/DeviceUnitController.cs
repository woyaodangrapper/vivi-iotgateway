using Vivi.Dcs.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("device/unit")]
public class DeviceUnitController : PlusControllerBase
{
    private readonly IDeviceUnitAppService _deviceUnitAppService;

    public DeviceUnitController(IDeviceUnitAppService deviceUnitAppService) => _deviceUnitAppService = deviceUnitAppService;

    /// <summary>
    /// 查询设备传感器
    /// </summary>
    /// <returns></returns>
    [HttpGet, Route("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SearchPage<DeviceUnitDto>>> GetPagedAsync([FromQuery] DeviceUnitQueryDto request)
    => await _deviceUnitAppService.GetPagedAsync(request);
}
