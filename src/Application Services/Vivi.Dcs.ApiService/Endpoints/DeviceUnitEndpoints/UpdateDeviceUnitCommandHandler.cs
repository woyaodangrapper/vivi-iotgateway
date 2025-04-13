using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.DeviceUnitEndpoints;

// 传感器端点-增删改查分离的中间人设计模式
public record DeviceUnitUpdate(string Id, UpdateDeviceUnitCommand Update) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/device/unit")]
public class UpdateDeviceUnitCommandHandler(
  IDeviceUnitAppService deviceUnitAppService,
  ILogger<UpdateDeviceUnitCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<DeviceUnitUpdate>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceUnitAppService _deviceUnitService = deviceUnitAppService;

    [HttpPut("update")]
    [SwaggerOperation(
      Summary = "更新传感器",
      Description = "根据传感器 ID 更新传感器参数",
      OperationId = "UnitUpdate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync([FromBody] DeviceUnitUpdate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _deviceUnitService.UpdateAsync(new()
        {

        })).Build();
    }
}