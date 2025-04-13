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
    [HttpPost, Route("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SearchPage<UnitCapabMapDTO>>> GetPagedAsync([FromBody] UnitCapabMapQueryDTO request)
    => await _unitCapabMapAppService.GetPagedAsync(request);
}
