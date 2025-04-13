using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;
using Vivi.SharedKernel.Application.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Endpoints.UnitCapabilityMap;

// 设备传感器能力映射端点-增删改查分离的中间人设计模式
public record UnitCapabilityMapCreate(CreateUnitCapabMapCommand Create) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/unit/capab/map")]
public class CreateUnitCapabMapCommandHandler(
  IDeviceAppService unitCapabMapAppService,
  ILogger<CreateUnitCapabMapCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<UnitCapabilityMapCreate>
  .WithActionResult<IdDTO>
{
    private readonly IDeviceAppService _unitCapabMapService = unitCapabMapAppService;

    [HttpPost("create")]
    [SwaggerOperation(
      Summary = "创建设备传感器能力映射",
      Description = "根据设备传感器能力映射添加设备传感器能力映射",
      OperationId = "UnitCapabilityMapCreate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<IdDTO>> HandleAsync([FromBody] UnitCapabilityMapCreate request, CancellationToken cancellationToken = default)
    {
        return (await _unitCapabMapService.CreateAsync(new()
        {

        })).Build();
    }
}