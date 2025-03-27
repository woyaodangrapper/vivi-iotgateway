using Vivi.Dcs.Contracts.Services;
using Vivi.Dcs.Entities;
using Vivi.SharedKernel.Const;
using Vivi.SharedKernel.Rpc.Http.Services;

namespace Vivi.Dcs.Application.Registrar;

public sealed class DcsApplicationDependencyRegistrar : AbstractApplicationDependencyRegistrar
{
    public override Assembly ApplicationLayerAssembly => Assembly.GetExecutingAssembly();

    public override Assembly ContractsLayerAssembly => typeof(ISayHelloAppService).Assembly;

    public override Assembly RepositoryOrDomainLayerAssembly => typeof(EntityInfo).Assembly;

    public DcsApplicationDependencyRegistrar(IServiceCollection services) : base(services)
    {
    }

    public override void AddServes()
    {
        AddApplicaitonDefault();
        //rpc-event

        //rpc-restclient
        var restPolicies = this.GenerateDefaultRefitPolicies();
        AddRestClient<IAuthRestClient>(ServiceAddressConsts.UsrService, restPolicies);
        AddRestClient<IUsrRestClient>(ServiceAddressConsts.UsrService, restPolicies);

        //rpc-grpcclient
        var gprcPolicies = this.GenerateDefaultGrpcPolicies();

        //rpc-even
        AddRabbitMqClient();
    }
}