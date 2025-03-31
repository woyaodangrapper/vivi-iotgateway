using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vivi.Dcs.Application.Commands.SmartDevice;
using Vivi.Dcs.Contracts.IServices;
namespace Vivi.Dcs.ApiService.Endpoints.TelemEndpoints;

// 设备端点-增删改查分离的中间人设计模式
public record DeviceCreate(CreateDeviceCommand Command) : IRequest<Task<string>>;

[Route("/endpoints/smart/device")]
public class CreateDeviceCommandHandler : EndpointBaseAsync
  .WithRequest<DeviceCreate>
  .WithActionResult<string>
{
    private readonly ISmartDeviceAppService _deviceService;

    public CreateDeviceCommandHandler(
      ISmartDeviceAppService smartDeviceAppService,
      ILogger<CreateDeviceCommandHandler> logger)
    {
        _deviceService = smartDeviceAppService;
    }

    [HttpPost("create")]
    [SwaggerOperation(
      Summary = "Summary",
      Description = "Description",
      OperationId = "Device.Create",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<string>> HandleAsync(DeviceCreate? request = null, CancellationToken cancellationToken = default)
    {
        return Ok(await _deviceService.CreateAsync(new()
        {
            Name = "123",
            InstallationLocation = "123",
            Manufacturer = "123",
            Model = "123"
        }));
    }
}

