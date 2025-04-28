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
    /// 查询区域结构
    /// </summary>
    /// <returns>树形类型的 <see cref="AreaTreeNodeDTO"/> 对象</returns>
    [HttpPost("query/nodes")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AreaTreeNodeDTO>>> GetNodesAsync([FromBody] AreaQueryDTO request)
    => await areaAppService.GetNodesAsync(request);

    /// <summary>
    /// 删除区域结构
    /// </summary>
    /// <returns>树形类型的 <see cref="AreaTreeNodeDTO"/> 对象</returns>
    [HttpDelete("delete/nodes")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteNodesAsync([FromBody] AreaTreeNodeDTO[] request)
    => Result(await areaAppService.DeleteNodesAsync(request));


    /// <summary>
    /// 添加或更新地区列表
    /// </summary>
    /// <returns>列表类型的 <see cref="AreaDTO"/> 对象</returns>
    [HttpPost("addOrUpdate")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IdDTO[]>> AddOrUpdateRangeAsync([FromBody] AreaTreeNodeDTO[] request)
    {
        var result = await areaAppService.AddOrUpdateRangeAsync(request);
        if (result.Content == null)
            return Result(result.ProblemDetails);
        return CreatedResult(result);
    }


    /// <summary>
    /// 删除或更新地区列表
    /// </summary>
    /// <returns></returns>
    [HttpPost("delOrUpdate")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteOrUpdateRangeAsync([FromBody] AreaRequestDTO[] request)
     => Result(await areaAppService.DeleteOrUpdateRangeAsync(request));
}
