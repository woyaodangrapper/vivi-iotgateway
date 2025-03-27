using Vivi.SharedKernel.ApiService.Middleware;
using Vivi.SharedKernel.Application.Extensions;

namespace Vivi.SharedKernel.ApiService.Registrar;

public abstract partial class AbstractWebApiDependencyRegistrar : IMiddlewareRegistrar
{
    protected readonly IApplicationBuilder App;
    protected AbstractWebApiDependencyRegistrar(IApplicationBuilder app)
    {
        App = app;
    }

    /// <summary>
    /// 注册中间件入口方法
    /// </summary>
    /// <param name="app"></param>
    public abstract void UseDcs();

    /// <summary>
    /// 注册webapi通用中间件
    /// </summary>
    protected virtual void UseWebApiDefault(
        Action<IApplicationBuilder> beforeAuthentication = null,
        Action<IApplicationBuilder> afterAuthentication = null,
        Action<IApplicationBuilder> afterAuthorization = null,
        Action<IEndpointRouteBuilder> endpointRoute = null)
    {
        ServiceLocator.Provider = App.ApplicationServices;
        var environment = App.ApplicationServices.GetService<IHostEnvironment>();
        var serviceInfo = App.ApplicationServices.GetService<IServiceInfo>();

        var defaultFilesOptions = new DefaultFilesOptions();
        defaultFilesOptions.DefaultFileNames.Clear();
        defaultFilesOptions.DefaultFileNames.Add("index.html");
        App
            .UseDefaultFiles(defaultFilesOptions)
            .UseStaticFiles()
            .UseCustomExceptionHandler()
            .UseRealIp(x => x.HeaderKey = "X-Forwarded-For")
            .UseCors(serviceInfo.CorsPolicy);

        if (environment.IsDevelopment())
        {
            App.UseMiniProfiler();
        }

        App
            .UseSwagger(c =>
            {
                c.RouteTemplate = $"/{serviceInfo.ShortName}/swagger/{{documentName}}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"/", Description = serviceInfo.Description } };
                });
            })
            .UseSwaggerUI(c =>
            {
                var assembly = serviceInfo.GetWebApiAssembly();
                c.IndexStream = () => assembly.GetManifestResourceStream($"{assembly.GetName().Name}.swagger_miniprofiler.html");
                c.SwaggerEndpoint($"/{serviceInfo.ShortName}/swagger/{serviceInfo.Version}/swagger.json", $"{serviceInfo.ServiceName}-{serviceInfo.Version}");
                c.RoutePrefix = $"{serviceInfo.ShortName}";
            })
            .UseRouting()
            .UseHttpMetrics();
        DotNetRuntimeStatsBuilder
        .Customize()
        .WithContentionStats()
        .WithGcStats()
        .WithThreadPoolStats()
        .StartCollecting();

        beforeAuthentication?.Invoke(App);
        App.UseAuthentication();
        afterAuthentication?.Invoke(App);
        App.UseAuthorization();
        afterAuthorization?.Invoke(App);

        App
            .UseEndpoints(endpoints =>
            {
                endpointRoute?.Invoke(endpoints);
                endpoints.MapMetrics();
                endpoints.MapControllers().RequireAuthorization();
            });
    }
}