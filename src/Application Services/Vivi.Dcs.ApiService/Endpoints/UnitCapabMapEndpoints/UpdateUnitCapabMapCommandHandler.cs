using Ardalis.ApiEndpoints;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SensorCapabilityMap;

// 设备端点-增删改查分离的中间人设计模式
public record SensorCapabilityMapUpdate(string Id, UpdateDeviceCommand Update) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/unit/capab/map")]
public class UpdateUnitCapabMapCommandHandler(
  IDeviceAppService smartDeviceAppService,
  ILogger<UpdateUnitCapabMapCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<SensorCapabilityMapUpdate>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _deviceService = smartDeviceAppService;

    [HttpPut("update")]
    [SwaggerOperation(
      Summary = "更新设备",
      Description = "根据设备 ID 更新智能设备参数",
      OperationId = "SensorCapabilityMapUpdate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync([FromBody] SensorCapabilityMapUpdate request, CancellationToken cancellationToken = default)
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