using Vivi.Dcs.Contracts.DTOs;
using Vivi.SharedKernel.Application.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("system/area")]
public class AreaController(IAreaAppService areaAppService) : PlusControllerBase
{

    /// <summary>
    /// ��ѯ����
    /// </summary>
    /// <returns>�б����͵� <see cref="AreaDTO"/> ����</returns>
    [HttpPost("query")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AreaDTO>>> GetListAsync([FromBody] AreaQueryDTO request)
    => await areaAppService.GetListAsync(request);


    /// <summary>
    /// ��ѯ����ṹ
    /// </summary>
    /// <returns>�������͵� <see cref="AreaTreeNodeDTO"/> ����</returns>
    [HttpPost("query/nodes")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AreaTreeNodeDTO>>> GetNodesAsync([FromBody] AreaQueryDTO request)
    => await areaAppService.GetNodesAsync(request);

    /// <summary>
    /// ɾ������ṹ
    /// </summary>
    /// <returns>�������͵� <see cref="AreaTreeNodeDTO"/> ����</returns>
    [HttpDelete("delete/nodes")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteNodesAsync([FromBody] AreaTreeNodeDTO[] request)
    => Result(await areaAppService.DeleteNodesAsync(request));


    /// <summary>
    /// ��ӻ���µ����б�
    /// </summary>
    /// <returns>�б����͵� <see cref="AreaDTO"/> ����</returns>
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
    /// ɾ������µ����б�
    /// </summary>
    /// <returns></returns>
    [HttpPost("delOrUpdate")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteOrUpdateRangeAsync([FromBody] AreaRequestDTO[] request)
     => Result(await areaAppService.DeleteOrUpdateRangeAsync(request));
}
