using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SmartDeviceEndpoints;

// 设备端点-增删改查分离的中间人设计模式
public record DeviceUpdate(string Id, UpdateDeviceCommand Update) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/device")]
public class UpdateDeviceCommandHandler(
  IDeviceAppService deviceAppService,
  ILogger<UpdateDeviceCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<DeviceUpdate>
  .WithActionResult
{
    private readonly IDeviceAppService _deviceService = deviceAppService;

    [HttpPut("update")]
    [SwaggerOperation(
      Summary = "更新设备",
      Description = "根据设备 ID 更新智能设备参数",
      OperationId = "DeviceUpdate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult> HandleAsync([FromBody] DeviceUpdate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _deviceService.UpdateAsync(new()
        {
            Id = new Guid(request.Id),
            Name = request.Update.Name,
            InstallationLocation = request.Update.InstallationLocation,
            Manufacturer = request.Update.Manufacturer,
            Model = request.Update.Model,
            UpdatedAt = DateTime.Now
        })).Build();
    }
}