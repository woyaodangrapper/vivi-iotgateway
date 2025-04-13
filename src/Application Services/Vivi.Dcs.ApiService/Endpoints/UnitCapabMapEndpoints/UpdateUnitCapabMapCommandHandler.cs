using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.UnitCapabilityMap;

// 设备传感器能力映射端点-增删改查分离的中间人设计模式
public record UnitCapabilityMapUpdate(string Id, UpdateUnitCapabMapCommand Update) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/unit/capab/map")]
public class UpdateUnitCapabMapCommandHandler(
  IDeviceAppService smartDeviceAppService,
  ILogger<UpdateUnitCapabMapCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<UnitCapabilityMapUpdate>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _deviceService = smartDeviceAppService;

    [HttpPut("update")]
    [SwaggerOperation(
      Summary = "更新设备传感器能力映射",
      Description = "根据设备传感器能力映射 ID 更新设备传感器能力映射参数",
      OperationId = "UnitCapabilityMapUpdate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync([FromBody] UnitCapabilityMapUpdate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _deviceService.UpdateAsync(new()
        {
            Id = new Guid(request.Id),
            UpdatedAt = DateTime.UtcNow

        })).Build();
    }
}