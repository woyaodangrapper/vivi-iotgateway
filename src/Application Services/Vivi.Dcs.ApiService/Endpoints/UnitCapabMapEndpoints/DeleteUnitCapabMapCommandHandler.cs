using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.UnitCapabilityMap;

// 设备传感器能力映射端点-增删改查分离的中间人设计模式
public record UnitCapabilityMapDelete(string Id) : IRequest<Task<ActionResult>>;

[Route("/endpoints/unit/capab/map")]
public class DeleteUnitCapabMapCommandHandler(
  IDeviceAppService smartDeviceAppService,
  ILogger<DeleteUnitCapabMapCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<UnitCapabilityMapDelete>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _deviceService = smartDeviceAppService;

    [HttpDelete("delete")]
    [SwaggerOperation(
      Summary = "删除设备传感器能力映射",
      Description = "根据设备传感器能力映射 ID 删除设备传感器能力映射",
      OperationId = "UnitCapabilityMapDelete",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync(UnitCapabilityMapDelete request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _deviceService.DeleteAsync(new(request.Id))).Build();
    }
}