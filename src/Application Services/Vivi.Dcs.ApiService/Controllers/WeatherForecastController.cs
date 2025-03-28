using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivi.Dcs.Contracts.DTOs;
using Vivi.Dcs.Contracts.Services;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : PlusControllerBase
{
    private readonly ISmartDeviceAppService _smartDeviceAppService;

    public WeatherForecastController(ISmartDeviceAppService smartDeviceAppService) => _smartDeviceAppService = smartDeviceAppService;

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<SmartDeviceDTO>>> GetListAsync() =>
        CreatedResult(await _smartDeviceAppService.GetListAsync());
}
