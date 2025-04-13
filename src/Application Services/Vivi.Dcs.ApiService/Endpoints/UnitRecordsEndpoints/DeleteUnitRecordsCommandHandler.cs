using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.UnitDataEndpoints;

// 传感器日志记录端点-增删改查分离的中间人设计模式
public record UnitDataDelete(string Id) : IRequest<Task<ActionResult>>;

[Route("endpoints")]
public class DeleteUnitRecordsCommandHandler(
  IDeviceAppService unitRecordsAppService,
  ILogger<DeleteUnitRecordsCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<UnitDataDelete>
  .WithActionResult
{
    private readonly IDeviceAppService _deviceService = unitRecordsAppService;

    [SwaggerOperation(
      Summary = "删除传感器日志记录",
      Description = "根据传感器日志记录 ID 删除传感器日志记录",
      OperationId = "UnitDataDelete",
      Tags = new[] { "Endpoints" })
    ]
    [HttpDelete("unit/records/delete")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public override async Task<ActionResult> HandleAsync(UnitDataDelete request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return (await _deviceService.DeleteAsync(new(request.Id))).Build();
    }
}