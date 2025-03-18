namespace Gravity.SharedKernel.Application.Extensions;

public static class ServiceCollectionExtension
{
    /// <summary>
    ///  统一注册Gravity.WebApi通用服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="serviceInfo"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    public static IServiceCollection AddGravity(this IServiceCollection services, IServiceInfo serviceInfo)
    {
        if (serviceInfo?.StartAssembly is null)
            throw new ArgumentNullException(nameof(serviceInfo));

        var webApiRegistarType = serviceInfo.StartAssembly.ExportedTypes.FirstOrDefault(m => m.IsAssignableTo(typeof(IDependencyRegistrar)) && m.IsNotAbstractClass(true));
        if (webApiRegistarType is null)
            throw new NullReferenceException(nameof(IDependencyRegistrar));

        var webapiRegistar = Activator.CreateInstance(webApiRegistarType, services) as IDependencyRegistrar;
        webapiRegistar?.AddDcs();

        return services;
    }
}