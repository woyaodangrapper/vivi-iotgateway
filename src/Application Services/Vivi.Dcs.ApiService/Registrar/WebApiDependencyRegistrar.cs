using Vivi.SharedKernel.ApiService.Registrar;

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
        AddWebApiDefault();
    }

    public override void UseService()
    {
        UseWebApiDefault(endpointRoute: endpoint =>
        {
        });
    }

}