using Ardalis.ApiEndpoints;
using Ardalis.ApiEndpoints.Expression;
using MediatR;
using Vivi.SharedKernel.Application.Contracts.DTOs;

namespace Vivi.Dcs.ApiService.Endpoints.SmartAreaEndpoints;

// 地区端点-增删改查分离的中间人设计模式
public record AreaCreate(CreateAreaCommand Create) : IRequest<Task<ActionResult>>;

[Route("/endpoints/area")]
public class CreateAreaCommandHandler(
  IAreaAppService smartAreaAppService,
  ILogger<CreateAreaCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<AreaCreate>
  .WithActionResult<IdDTO>
{
    private readonly IAreaAppService _areaService = smartAreaAppService;

    [HttpPost("create")]
    [SwaggerOperation(
      Summary = "创建地区",
      Description = "根据地区添加地区",
      OperationId = "AreaCreate",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<IdDTO>> HandleAsync([FromBody] AreaCreate request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Creating a new area with name {Name}", request.Create.Name);

        return (await _areaService.CreateAsync(new()
        {
            Name = request.Create.Name,
            Pid = request.Create.Pid,
        })).Build();
    }
}