using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SmartAreaEndpoints;

// 地区端点-增删改查分离的中间人设计模式
public record AreaDelete(string Id) : IRequest<Task<ActionResult>>;

[Route("/endpoints/area")]
public class DeleteAreaCommandHandler(
  IAreaAppService smartAreaAppService,
  ILogger<DeleteAreaCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<AreaDelete>
  .WithActionResult
{
    private readonly IAreaAppService _areaService = smartAreaAppService;

    [HttpDelete("delete")]
    [SwaggerOperation(
      Summary = "删除地区",
      Description = "根据地区 ID 删除地区",
      OperationId = "AreaDelete",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult> HandleAsync(AreaDelete request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a area with id {Id}", request.Id);
        return (await _areaService.DeleteAsync(new(request.Id))).Build();
    }
}