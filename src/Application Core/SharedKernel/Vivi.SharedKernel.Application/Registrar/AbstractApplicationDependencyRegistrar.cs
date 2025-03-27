using Vivi.SharedKernel.Application.Services.Trackers;
using Vivi.SharedKernel.Const.AppSettings;

namespace Vivi.SharedKernel.Application.Registrar;

public abstract partial class AbstractApplicationDependencyRegistrar : IDependencyRegistrar
{
    public string Name => "application";
    public abstract Assembly ApplicationLayerAssembly { get; }
    public abstract Assembly ContractsLayerAssembly { get; }
    public abstract Assembly RepositoryOrDomainLayerAssembly { get; }
    protected SkyApmExtensions SkyApm { get; init; }
    protected IServiceCollection Services { get; init; }
    protected IConfiguration Configuration { get; init; }
    protected IServiceInfo ServiceInfo { get; init; }
    protected IConfigurationSection CachingSection { get; init; }
    protected IConfigurationSection MysqlSection { get; init; }
    protected IConfigurationSection SqlServerSection { get; init; }


    protected AbstractApplicationDependencyRegistrar(IServiceCollection services)
    {
        Services = services ?? throw new ArgumentException("IServiceCollection is null.");
        Configuration = services.GetConfiguration() ?? throw new ArgumentException("Configuration is null.");
        ServiceInfo = services.GetServiceInfo() ?? throw new ArgumentException("ServiceInfo is null.");
        CachingSection = Configuration.GetSection(NodeConsts.Caching);
        MysqlSection = Configuration.GetSection(NodeConsts.Mysql);
        SqlServerSection = Configuration.GetSection(NodeConsts.SqlServer);
        SkyApm = Services.AddSkyApmExtensions();
    }

    /// <summary>
    /// 注册所有服务
    /// </summary>
    public abstract void AddDcs();

    /// <summary>
    /// application通用服务
    /// </summary>
    protected virtual void AddApplicaitonDefault()
    {
        Services
            .AddValidatorsFromAssembly(ContractsLayerAssembly, ServiceLifetime.Scoped)
            .AddDcsInfraAutoMapper(ApplicationLayerAssembly)
            .AddDcsInfraDapper();

        AddApplicationSharedServices();
        AddAppliactionSerivcesWithInterceptors();
        AddApplicaitonHostedServices();
        AddEfCoreContextWithRepositories();
    }

    /// <summary>
    /// 注册application.shared层服务
    /// </summary>
    protected void AddApplicationSharedServices()
    {
        Services.AddSingleton(typeof(Lazy<>));
        Services.AddScoped<MessageTrackerFactory>();
    }
}