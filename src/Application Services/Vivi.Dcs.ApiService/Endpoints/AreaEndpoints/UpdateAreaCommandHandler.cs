using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.SmartAreaEndpoints;

// 地区端点-增删改查分离的中间人设计模式
public record AreaUpdate(string Id, UpdateAreaCommand Update) : IRequest<Task<AppSrvResult>>;

[Route("/endpoints/area")]
public class UpdateAreaCommandHandler(
  IAreaAppService smartAreaAppService,
  ILogger<UpdateAreaCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<AreaUpdate>
  .WithActionResult
{
    private readonly IAreaAppService _areaService = smartAreaAppService;

    [HttpPut("update")]
    [SwaggerOperation(
      Summary = "更新地区",
      Description = "根据地区 ID 更新地区参数",
      OperationId = "AreaUpdate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult> HandleAsync([FromBody] AreaUpdate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a area with id {Id}", request.Id);
        return (await _areaService.UpdateAsync(new()
        {
            Id = new Guid(request.Id),

            UpdatedAt = DateTime.UtcNow
        })).Build();
    }
}

