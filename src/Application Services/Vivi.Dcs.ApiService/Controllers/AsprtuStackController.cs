using Vivi.Dcs.Contracts.Requests;
using Vivi.SharedKernel.Contracts.Queue;

namespace Vivi.Dcs.ApiService.Controllers;

[ApiController]
[Route("asprtu")]
public class AsprtuStackController : PlusControllerBase
{
    protected readonly IPublisher<AsprtuVerify> _queuePublisher;

    public AsprtuStackController(IQueueFactory<AsprtuVerify> queueFactory)
    {
        _queuePublisher = queueFactory.CreatePublisher();
    }

    [HttpPost("a-{app_id}/register")]
    [AllowAnonymous]
    public IActionResult Verify(
         [FromRoute(Name = "app_id")] string appId)
    {
        return Ok(_queuePublisher.TryEnqueue(new AsprtuVerify()
        {
            AppId = appId,
            //Timestamp = timestamp,
            //Nonce = nonce,
            //Signature = signature,
            //EchoString = echoString
        }));
    }
}