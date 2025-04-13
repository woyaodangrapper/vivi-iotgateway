using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.DeviceUnitEndpoints;

// 传感器端点-增删改查分离的中间人设计模式
public record DeviceUnitDelete(string Id) : IRequest<Task<ActionResult>>;

[Route("/endpoints/device/unit")]
public class DeleteDeviceUnitCommandHandler(
  IDeviceUnitAppService deviceUnitAppService,
  ILogger<DeleteDeviceUnitCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<DeviceUnitDelete>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceUnitAppService _deviceUnitService = deviceUnitAppService;

    [HttpDelete("delete")]
    [SwaggerOperation(
      Summary = "删除传感器",
      Description = "根据传感器 ID 删除传感器",
      OperationId = "UnitDelete",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync(DeviceUnitDelete request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _deviceUnitService.DeleteAsync(new(request.Id))).Build();
    }
}