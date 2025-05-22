using Vivi.Dcs.Contracts.Requests;
using Vivi.SharedKernel.ApiService.Registrar;
using Vivi.SharedKernel.Application.Extensions;

namespace Vivi.Dcs.ApiService.Registrar;

public sealed class WebApiDependencyRegistrar : AbstractWebApiDependencyRegistrar
{
    public WebApiDependencyRegistrar(IServiceCollection services)
        : base(services)
    {
    }

    public WebApiDependencyRegistrar(IApplicationBuilder app)
        : base(app)
    {
    }

    public override void AddServes()
    {
        Services.AddQueueFactory<AsprtuVerify>();
        AddWebApiDefault();
    }

    public override void UseService()
    {
        UseWebApiDefault(endpointRoute: endpoint =>
        {
        });
    }
}