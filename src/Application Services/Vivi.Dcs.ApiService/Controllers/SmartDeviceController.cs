using Vivi.Dcs.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("smart/device")]
public class SmartDeviceController : PlusControllerBase
{
    private readonly ISmartDeviceAppService _smartDeviceAppService;

    public SmartDeviceController(ISmartDeviceAppService smartDeviceAppService) => _smartDeviceAppService = smartDeviceAppService;

    /// <summary>
    /// ≤È—Ø…Ë±∏
    /// </summary>
    /// <returns></returns>
    [HttpGet, Route("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SearchPage<DeviceDto>>> GetPagedAsync([FromQuery] DeviceQueryDto? request = null)
    {
        if (Request.Query.Count == 0)
            request = null;
        return await _smartDeviceAppService.GetPagedAsync(request);
    }
}
