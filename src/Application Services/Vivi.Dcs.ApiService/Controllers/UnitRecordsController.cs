using Vivi.Dcs.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("unit/records")]
public class UnitRecordsController : PlusControllerBase
{
    private readonly IUnitRecordsAppService _unitRecordsAppService;

    public UnitRecordsController(IUnitRecordsAppService unitRecordsAppService) => _unitRecordsAppService = unitRecordsAppService;

    /// <summary>
    /// 查询设备/传感器日志
    /// </summary>
    /// <returns></returns>
    [HttpGet, Route("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SearchPage<UnitRecordsDto>>> GetPagedAsync([FromQuery] UnitRecordsQueryDto request)
    => await _unitRecordsAppService.GetPagedAsync(request);
}
