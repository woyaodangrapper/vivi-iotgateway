using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.UnitDataEndpoints;

// 传感器日志记录端点-增删改查分离的中间人设计模式
public record UnitDataUpdate(string Id, UpdateUnitRecordsCommand Update) : IRequest<Task<AppSrvResult>>;

[Route("endpoints")]
public class UpdateUnitRecordsCommandHandler(
  IDeviceAppService unitRecordsAppService,
  ILogger<UpdateUnitRecordsCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<UnitDataUpdate>
  .WithActionResult<AppSrvResult>
{
    private readonly IDeviceAppService _deviceService = unitRecordsAppService;

    [SwaggerOperation(
      Summary = "更新传感器日志记录",
      Description = "根据传感器日志记录 ID 更新传感器日志记录参数",
      OperationId = "UnitDataUpdate",
      Tags = new[] { "Endpoints" })
    ]
    [HttpPut("unit/records/update")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync([FromBody] UnitDataUpdate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _deviceService.UpdateAsync(new()
        {
            Id = new Guid(request.Id),

        })).Build();
    }

}