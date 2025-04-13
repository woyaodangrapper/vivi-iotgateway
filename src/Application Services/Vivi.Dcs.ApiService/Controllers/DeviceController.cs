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
    /// <returns><see cref="SearchPage{DeviceDTO}"/></returns>
    [HttpPost("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SearchPage<DeviceDTO>>> GetPagedAsync([FromBody] DeviceQueryDTO request)
    => await _deviceAppService.GetPagedAsync(request);
}
