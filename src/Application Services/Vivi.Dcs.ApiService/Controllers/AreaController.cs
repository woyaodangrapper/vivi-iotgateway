using Vivi.Dcs.Contracts.DTOs;
using Vivi.SharedKernel.Application.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("system/area")]
public class AreaController(IAreaAppService areaAppService) : PlusControllerBase
{

    /// <summary>
    /// 查询区域
    /// </summary>
    /// <returns>列表类型的 <see cref="AreaDTO"/> 对象</returns>
    [HttpPost("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AreaDTO>>> GetListAsync([FromBody] AreaQueryDTO request)
    => await areaAppService.GetListAsync(request);

    /// <summary>
    /// 添加或更新地区列表
    /// </summary>
    /// <returns>列表类型的 <see cref="AreaDTO"/> 对象</returns>
    [HttpPost("addOrUpdate")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IdDTO[]>> AddOrUpdateRangeAsync([FromBody] AreaRequestDTO[] request)
    => CreatedResult(await areaAppService.AddOrUpdateRangeAsync(request));
}
