using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;
using Vivi.SharedKernel.Application.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Endpoints.DeviceUnitEndpoints;

// 传感器端点-增删改查分离的中间人设计模式
public record DeviceUnitCreate(CreateDeviceUnitCommand Create) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/device/unit")]
public class CreateDeviceUnitCommandHandler(
  IDeviceUnitAppService deviceUnitAppService,
  ILogger<CreateDeviceUnitCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<DeviceUnitCreate>
  .WithActionResult<IdDTO>
{
    private readonly IDeviceUnitAppService _deviceUnitService = deviceUnitAppService;

    [HttpPost("create")]
    [SwaggerOperation(
      Summary = "创建传感器",
      Description = "根据传感器添加传感器",
      OperationId = "UnitCreate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<IdDTO>> HandleAsync([FromBody] DeviceUnitCreate request, CancellationToken cancellationToken = default)
    {
        //logger.LogInformation("Creating a new unit with name {Name}", request.Create.Name);
        return (await _deviceUnitService.CreateAsync(new()
        {
        })).Build();
    }
}