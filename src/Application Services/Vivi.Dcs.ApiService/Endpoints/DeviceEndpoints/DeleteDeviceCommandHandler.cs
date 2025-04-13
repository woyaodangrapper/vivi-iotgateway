using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SmartDeviceEndpoints;

// 设备端点-增删改查分离的中间人设计模式
public record DeviceDelete(string Id) : IRequest<Task<ActionResult>>;

[Route("/endpoints/device")]
public class DeleteDeviceCommandHandler(
  IDeviceAppService deviceAppService,
  ILogger<DeleteDeviceCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<DeviceDelete>
  .WithActionResult
{
    private readonly IDeviceAppService _deviceService = deviceAppService;

    [HttpDelete("delete")]
    [SwaggerOperation(
      Summary = "删除设备",
      Description = "根据设备 ID 删除智能设备",
      OperationId = "DeviceDelete",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult> HandleAsync(DeviceDelete request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _deviceService.DeleteAsync(new(request.Id))).Build();
    }
}