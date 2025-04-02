using Ardalis.ApiEndpoints;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SensorDataEndpoints;

// 设备端点-增删改查分离的中间人设计模式
public record SensorDataUpdate(string Id, UpdateDeviceCommand Update) : IRequest<Task<AppSrvResult>>;

[Route("endpoints")]
public class UpdateUnitRecordsCommandHandler(
  IDeviceAppService smartDeviceAppService,
  ILogger<UpdateUnitRecordsCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<SensorDataUpdate>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _deviceService = smartDeviceAppService;

    [SwaggerOperation(
      Summary = "更新设备",
      Description = "根据设备 ID 更新智能设备参数",
      OperationId = "SensorDataUpdate",
      Tags = new[] { "Endpoints" })
    ]
    [HttpPut("unit/records/update")]
    [AllowAnonymous]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync([FromBody] SensorDataUpdate request, CancellationToken cancellationToken = default)
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