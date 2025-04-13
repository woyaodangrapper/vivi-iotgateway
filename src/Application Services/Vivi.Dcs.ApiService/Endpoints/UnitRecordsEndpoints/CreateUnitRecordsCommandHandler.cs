using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;
using Vivi.SharedKernel.Application.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Endpoints.UnitRecordsEndpoints;

// 传感器日志记录端点-增删改查分离的中间人设计模式
public record UnitRecordsCreate(CreateUnitRecordsCommand Create) : IRequest<Task<long>>;

[Route("endpoints")]
public class CreateUnitRecordsCommandHandler(
  IDeviceAppService unitRecordsAppService,
  ILogger<CreateUnitRecordsCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<UnitRecordsCreate>
  .WithActionResult<IdDTO>
{
    private readonly IDeviceAppService _deviceService = unitRecordsAppService;

    [SwaggerOperation(
      Summary = "创建传感器日志记录",
      Description = "根据传感器日志记录添加传感器日志记录",
      OperationId = "UnitRecordsCreate",
      Tags = new[] { "Endpoints" })
    ]
    [HttpPost("unit/records/create")]
    [AllowAnonymous]
    public override async Task<ActionResult<IdDTO>> HandleAsync([FromBody] UnitRecordsCreate request, CancellationToken cancellationToken = default)
    {
        //logger.LogInformation("Creating a new device with name {Name}", request.Create.Name);
        return (await _deviceService.CreateAsync(new()
        {

        })).Build();

    }
}