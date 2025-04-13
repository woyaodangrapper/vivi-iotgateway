using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.UnitCapabilityEndpoints;

// 传感器能力端点-增删改查分离的中间人设计模式
public record UnitCapabilityDelete(string Id) : IRequest<Task<ActionResult>>;

[Route("/endpoints/unit/capab")]
public class DeleteUnitCapabCommandHandler(
  IDeviceAppService unitCapabAppService,
  ILogger<DeleteUnitCapabCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<UnitCapabilityDelete>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _unitCapabService = unitCapabAppService;

    [HttpDelete("delete")]
    [SwaggerOperation(
      Summary = "删除传感器能力",
      Description = "根据传感器能力 ID 删除传感器能力",
      OperationId = "UnitCapabilityDelete",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync(UnitCapabilityDelete request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _unitCapabService.DeleteAsync(new(request.Id))).Build();
    }
}