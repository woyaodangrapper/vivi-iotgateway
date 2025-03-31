using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vivi.Dcs.ApiService.Endpoints;

[ApiController]
[Route("api/[controller]")]
public abstract class EndpointControllerBase : PlusControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
