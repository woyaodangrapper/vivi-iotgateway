using Ardalis.ApiEndpoints;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SensorCapabilityMap;

// 设备端点-增删改查分离的中间人设计模式
public record SensorCapabilityMapDelete(string Id) : IRequest<Task<ActionResult>>;

[Route("/endpoints/unit/capab/map")]
public class DeleteUnitCapabMapCommandHandler(
  IDeviceAppService smartDeviceAppService,
  ILogger<DeleteUnitCapabMapCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<SensorCapabilityMapDelete>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _deviceService = smartDeviceAppService;

    [HttpDelete("delete")]
    [SwaggerOperation(
      Summary = "删除设备",
      Description = "根据设备 ID 删除智能设备",
      OperationId = "SensorCapabilityMapDelete",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync(SensorCapabilityMapDelete request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return Ok(await _deviceService.DeleteAsync(new(request.Id)));
    }
}