using Ardalis.ApiEndpoints;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SmartDeviceEndpoints;

// 设备端点-增删改查分离的中间人设计模式
public record DeviceCreate(CreateDeviceCommand Create) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/device")]
public class CreateDeviceCommandHandler(
  IDeviceAppService smartDeviceAppService,
  ILogger<CreateDeviceCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<DeviceCreate>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _deviceService = smartDeviceAppService;

    [HttpPost("create")]
    [SwaggerOperation(
      Summary = "创建设备",
      Description = "根据设备添加智能设备",
      OperationId = "DeviceCreate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync(DeviceCreate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Creating a new device with name {Name}", request.Create.Name);
        return Ok(await _deviceService.CreateAsync(new()
        {
            Name = request.Create.Name,
            InstallationLocation = request.Create.InstallationLocation,
            Manufacturer = request.Create.Manufacturer,
            Model = request.Create.Model
        }));
    }
}