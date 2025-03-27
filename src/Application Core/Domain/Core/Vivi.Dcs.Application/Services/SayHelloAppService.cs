using Vivi.Dcs.Contracts.Dtos;
using Vivi.Dcs.Contracts.Services;

namespace Vivi.Dcs.Application.Services;

public class SayHelloAppService : AbstractAppService, ISayHelloAppService
{
    public async Task<AppSrvResult<List<HelloDto>>> GetListAsync()
    {
        return await Task.FromResult(new List<HelloDto>() { new () {
         Content ="Hello World",
        } });
    }
}