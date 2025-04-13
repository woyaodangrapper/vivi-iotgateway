using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;
using Vivi.SharedKernel.Application.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Endpoints.UnitCapabilityEndpoints;

// 传感器能力端点-增删改查分离的中间人设计模式
public record UnitCapabilityCreate(CreateUnitCapabCommand Create) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/unit/capab")]
public class CreateUnitCapabCommandHandler(
  IDeviceAppService unitCapabAppService,
  ILogger<CreateUnitCapabCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<UnitCapabilityCreate>
  .WithActionResult<IdDTO>
{
    private readonly IDeviceAppService _unitCapabService = unitCapabAppService;

    [HttpPost("create")]
    [SwaggerOperation(
      Summary = "创建传感器能力",
      Description = "根据传感器能力添加传感器能力",
      OperationId = "UnitCapabilityCreate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<IdDTO>> HandleAsync([FromQuery] UnitCapabilityCreate request, CancellationToken cancellationToken = default)
    {
        //logger.LogInformation("Creating a new device with name {Name}", request.Create.Name);
        return (await _unitCapabService.CreateAsync(new()
        {
        })).Build();
    }
}