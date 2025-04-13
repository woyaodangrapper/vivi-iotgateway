using Microsoft.Extensions.DependencyInjection.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vivi.SharedKernel.Application.FluentValidation;

namespace Vivi.SharedKernel.Application.Extensions;

public static class FluentValidationExtensions
{

    public static IServiceCollection AddSimpleFluentValidation(this IServiceCollection services)
    {
        services.TryAdd(new ServiceDescriptor(typeof(IValidatorRegistry), typeof(ServiceProviderValidatorRegistry), ServiceLifetime.Singleton));
        services.TryAdd(new ServiceDescriptor(typeof(ISchemaFilter), typeof(FluentValidationSchemaFilter), ServiceLifetime.Singleton));

        return services;
    }
}

public class ServiceProviderValidatorRegistry : IValidatorRegistry
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceProviderValidatorRegistry(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public IValidator? GetValidator(Type type) =>
        _serviceProvider.GetService(typeof(IValidator<>).MakeGenericType(type)) as IValidator
        ?? throw new InvalidOperationException($"未找到 {type} 的 Validator");

    public IValidator<T>? GetValidator<T>() => _serviceProvider.GetService<IValidator<T>>();
}

public interface IValidatorRegistry
{
    IValidator? GetValidator(Type type);
    IValidator<T>? GetValidator<T>();
}
