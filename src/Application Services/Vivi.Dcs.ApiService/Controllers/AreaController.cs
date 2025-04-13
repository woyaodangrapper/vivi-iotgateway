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
    /// ��ӻ���µ����б�
    /// </summary>
    /// <returns>�б����͵� <see cref="AreaDTO"/> ����</returns>
    [HttpPost("addOrUpdate")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IdDTO[]>> AddOrUpdateRangeAsync([FromBody] AreaRequestDTO[] request)
    => CreatedResult(await areaAppService.AddOrUpdateRangeAsync(request));
}
