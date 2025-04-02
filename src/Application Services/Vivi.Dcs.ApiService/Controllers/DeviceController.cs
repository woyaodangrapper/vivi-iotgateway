using Vivi.Dcs.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("device")]
public class DeviceController : PlusControllerBase
{
    private readonly IDeviceAppService _deviceAppService;

    public DeviceController(IDeviceAppService deviceAppService) => _deviceAppService = deviceAppService;

    /// <summary>
    /// ≤È—Ø…Ë±∏
    /// </summary>
    /// <returns></returns>
    [HttpGet("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SearchPage<DeviceDto>>> GetPagedAsync([FromQuery] DeviceQueryDto request)
    => await _deviceAppService.GetPagedAsync(request);
}
