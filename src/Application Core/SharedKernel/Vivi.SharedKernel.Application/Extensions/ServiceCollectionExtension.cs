using Microsoft.Extensions.DependencyInjection.Extensions;
using Vivi.SharedKernel.Application.Queue;
using Vivi.SharedKernel.Contracts.Queue;

namespace Vivi.SharedKernel.Application.Extensions;

public static class ServiceCollectionExtension
{
    /// <summary>
    ///  统一注册Vivi.WebApi通用服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="serviceInfo"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    public static IServiceCollection AddVivi(this IServiceCollection services, IServiceInfo serviceInfo)
    {
        if (serviceInfo?.StartAssembly is null)
            throw new ArgumentNullException(nameof(serviceInfo));

        var webApiRegistarType = serviceInfo.StartAssembly.ExportedTypes.FirstOrDefault(m =>
        m.IsAssignableTo(typeof(IDependencyRegistrar)) && m.IsNotAbstractClass(true))
            ?? throw new NullReferenceException(nameof(IDependencyRegistrar));

        var webapiRegistar = Activator.CreateInstance(webApiRegistarType, services) as IDependencyRegistrar;
        webapiRegistar?.AddServes();

        return services;
    }

    /// <summary>
    /// 注册 <see cref="IQueueFactory{T}"/> 及其实现 <see cref="QueueFactory{T}"/>，
    /// 用于创建和管理指定类型 <typeparamref name="T"/> 的队列客户端。
    /// </summary>
    /// <typeparam name="T">队列中处理的数据类型。</typeparam>
    /// <param name="services">要注册服务的 <see cref="IServiceCollection"/> 实例。</param>
    /// <returns>用于链式调用的 <see cref="IServiceCollection"/> 实例。</returns>
    public static IServiceCollection AddQueueFactory<T>(this IServiceCollection services)
    {
        services.TryAddSingleton<IQueueFactory<T>, QueueFactory<T>>();
        return services;
    }

    /// <summary>
    /// 注册 <see cref="IQueueFactory{T}"/> 及其实现 <see cref="QueueFactory{T}"/>，
    /// 并允许通过指定名称初始化队列客户端。
    /// </summary>
    /// <typeparam name="T">队列中处理的数据类型。</typeparam>
    /// <param name="services">要注册服务的 <see cref="IServiceCollection"/> 实例。</param>
    /// <param name="name">队列的自定义名称。</param>
    /// <returns>用于链式调用的 <see cref="IServiceCollection"/> 实例。</returns>
    public static IServiceCollection AddQueueFactory<T>(this IServiceCollection services, string name)
    {
        services.TryAddSingleton<IQueueFactory<T>>(provider =>
            new QueueFactory<T>(name));
        return services;
    }
}