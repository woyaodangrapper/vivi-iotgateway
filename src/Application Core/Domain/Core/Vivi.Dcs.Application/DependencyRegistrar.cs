using Vivi.Dcs.Contracts.IServices;
using Vivi.Dcs.Entities;

namespace Vivi.Dcs.Application.Registrar;

public sealed class DependencyRegistrar(IServiceCollection services) : AbstractApplicationDependencyRegistrar(services)
{
    private readonly Assembly _assembly = Assembly.GetExecutingAssembly();
    public override Assembly ApplicationLayerAssembly => _assembly;
    public override Assembly ContractsLayerAssembly => typeof(ISmartDeviceAppService).Assembly;
    public override Assembly RepositoryOrDomainLayerAssembly => typeof(EntityInfo).Assembly;

    public override void AddServes()
    {
        AddApplicaitonDefault();
    }
}