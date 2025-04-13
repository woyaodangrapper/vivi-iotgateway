using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.UnitCapabilityEndpoints;

// 传感器能力端点-增删改查分离的中间人设计模式
public record UnitCapabilityUpdate(string Id, UpdateUnitCapabCommand Update) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/unit/capab")]
public class UpdateUnitCapabCommandHandler(
  IDeviceAppService unitCapabAppService,
  ILogger<UpdateUnitCapabCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<UnitCapabilityUpdate>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _unitCapabService = unitCapabAppService;

    [HttpPut("update")]
    [SwaggerOperation(
      Summary = "更新传感器能力",
      Description = "根据传感器能力 ID 更新传感器能力参数",
      OperationId = "UnitCapabilityUpdate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync([FromBody] UnitCapabilityUpdate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _unitCapabService.UpdateAsync(new()
        {
            Id = new Guid(request.Id),
            UpdatedAt = DateTime.UtcNow
        })).Build();
    }
}