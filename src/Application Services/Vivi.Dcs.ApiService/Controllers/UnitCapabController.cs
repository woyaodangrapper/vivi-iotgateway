using Vivi.Dcs.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("unit/capab")]
public class UnitCapabController : PlusControllerBase
{
    private readonly IUnitCapabAppService _unitCapabAppService;

    public UnitCapabController(IUnitCapabAppService unitCapabAppService) => _unitCapabAppService = unitCapabAppService;

    /// <summary>
    /// 查询传感器能力
    /// </summary>
    /// <returns></returns>
    [HttpGet, Route("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SearchPage<UnitCapabDto>>> GetPagedAsync([FromQuery] UnitCapabQueryDto request)
    => await _unitCapabAppService.GetPagedAsync(request);
}
