using Ardalis.ApiEndpoints;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SensorDataEndpoints;

// 设备端点-增删改查分离的中间人设计模式
public record SensorDataCreate(CreateDeviceCommand Create) : IRequest<Task<AppSrvResult>>;

[Route("endpoints")]
public class CreateUnitRecordsCommandHandler(
  IDeviceAppService smartDeviceAppService,
  ILogger<CreateUnitRecordsCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<SensorDataCreate>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _deviceService = smartDeviceAppService;

    [SwaggerOperation(
      Summary = "创建设备",
      Description = "根据设备添加智能设备",
      OperationId = "SensorDataCreate",
      Tags = new[] { "Endpoints" })
    ]
    [HttpPost("unit/records/create")]
    [AllowAnonymous]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync(SensorDataCreate request, CancellationToken cancellationToken = default)
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