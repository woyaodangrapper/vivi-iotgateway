using Ardalis.ApiEndpoints;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SensorCapabilityMap;

// 设备端点-增删改查分离的中间人设计模式
public record SensorCapabilityMapCreate(CreateDeviceCommand Create) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/unit/capab/map")]
public class CreateUnitCapabMapCommandHandler(
  IDeviceAppService smartDeviceAppService,
  ILogger<CreateUnitCapabMapCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<SensorCapabilityMapCreate>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _deviceService = smartDeviceAppService;

    [HttpPost("create")]
    [SwaggerOperation(
      Summary = "创建设备",
      Description = "根据设备添加智能设备",
      OperationId = "SensorCapabilityMapCreate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync(SensorCapabilityMapCreate request, CancellationToken cancellationToken = default)
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