using Vivi.Dcs.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("unit/capab")]
public class UnitCapabController : PlusControllerBase
{
    private readonly IUnitCapabAppService _unitCapabAppService;

    public UnitCapabController(IUnitCapabAppService unitCapabAppService) => _unitCapabAppService = unitCapabAppService;

    /// <summary>
    /// ��ѯ����������
    /// </summary>
    /// <returns></returns>
    [HttpPost, Route("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SearchPage<UnitCapabDTO>>> GetPagedAsync([FromBody] UnitCapabQueryDTO request)
    => await _unitCapabAppService.GetPagedAsync(request);
}
