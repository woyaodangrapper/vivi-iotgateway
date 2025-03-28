namespace Vivi.SharedKernel.ApiService.Registrar;

public abstract partial class AbstractWebApiDependencyRegistrar : IDependencyRegistrar
{
    public string Name => "apiservice";
    protected IConfiguration Configuration { get; init; }
    protected IServiceCollection Services { get; init; }
    protected IServiceInfo ServiceInfo { get; init; }

    /// <summary>
    /// 服务注册与系统配置
    /// </summary>
    /// <param name="services"><see cref="IServiceInfo"/></param>
    protected AbstractWebApiDependencyRegistrar(IServiceCollection services)
    {
        Services = services;
        Configuration = services.GetConfiguration();
        ServiceInfo = services.GetServiceInfo();
    }

    /// <summary>
    /// 注册服务入口方法
    /// </summary>
    public abstract void AddServes();


    /// <summary>
    /// 注册Webapi通用的服务
    /// </summary>
    protected virtual void AddWebApiDefault()
    {

        Services
            .AddHttpContextAccessor()
            .AddMemoryCache();
        Configure();
        AddControllers();
        AddCors();
        AddSwaggerGen();
        AddMiniProfiler();
        AddApplicationServices();
    }
}