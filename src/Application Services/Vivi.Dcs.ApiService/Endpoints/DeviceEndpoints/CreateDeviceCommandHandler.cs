using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;
using Vivi.SharedKernel.Application.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Endpoints.SmartDeviceEndpoints;

// 设备端点-增删改查分离的中间人设计模式
public record DeviceCreate(CreateDeviceCommand Create) : IRequest<Task<ActionResult>>;

[Route("/endpoints/device")]
public class CreateDeviceCommandHandler(
  IDeviceAppService deviceAppService,
  ILogger<CreateDeviceCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<DeviceCreate>
  .WithActionResult<IdDTO>
{
    private readonly IDeviceAppService _deviceService = deviceAppService;

    [HttpPost("create")]
    [SwaggerOperation(
      Summary = "创建设备",
      Description = "根据设备添加智能设备",
      OperationId = "DeviceCreate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<IdDTO>> HandleAsync([FromBody] DeviceCreate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Creating a new device with name {Name}", request.Create.Name);

        return (await _deviceService.CreateAsync(new()
        {
            Name = request.Create.Name,
            InstallationLocation = request.Create.InstallationLocation,
            Manufacturer = request.Create.Manufacturer,
            Model = request.Create.Model
        })).Build();
    }
}