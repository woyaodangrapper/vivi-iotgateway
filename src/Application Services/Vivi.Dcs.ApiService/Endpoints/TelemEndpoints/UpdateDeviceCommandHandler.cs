using Ardalis.ApiEndpoints;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.TelemEndpoints;

// 设备端点-增删改查分离的中间人设计模式
public record DeviceUpdate(string Id, UpdateDeviceCommand Update) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/smart/device")]
public class UpdateDeviceCommandHandler(
  ISmartDeviceAppService smartDeviceAppService,
  ILogger<UpdateDeviceCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<DeviceUpdate>
  .WithActionResult<AppSrvResult>
{
    private readonly ISmartDeviceAppService _deviceService = smartDeviceAppService;

    [HttpPut("update")]
    [SwaggerOperation(
      Summary = "更新设备",
      Description = "根据设备 ID 更新智能设备参数",
      OperationId = "Device.Update",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync([FromBody] DeviceUpdate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return Ok(await _deviceService.UpdateAsync(new()
        {
            Id = new Guid(request.Id),
            Name = request.Update.Name,
            InstallationLocation = request.Update.InstallationLocation,
            Manufacturer = request.Update.Manufacturer,
            Model = request.Update.Model,
        }));
    }
}