using Vivi.Dcs.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("unit/capab/map")]
public class UnitCapabMapController : PlusControllerBase
{
    private readonly IUnitCapabMapAppService _unitCapabMapAppService;

    public UnitCapabMapController(IUnitCapabMapAppService unitCapabMapAppService) => _unitCapabMapAppService = unitCapabMapAppService;

    /// <summary>
    /// 查询传感器能力映射
    /// </summary>
    /// <returns></returns>
    [HttpGet, Route("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SearchPage<UnitCapabMapDto>>> GetPagedAsync([FromQuery] UnitCapabMapQueryDto request)
    => await _unitCapabMapAppService.GetPagedAsync(request);
}
