using Gravity.Infrastructure.Mapper;
using Gravity.Infrastructure.Mapper.AutoMapper;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDcsInfraAutoMapper(this IServiceCollection services, params Type[] profileAssemblyMarkerTypes)
    {
        if (services.HasRegistered(nameof(AddDcsInfraAutoMapper)))
            return services;

        services.AddAutoMapper(profileAssemblyMarkerTypes);
        services.AddSingleton<IObjectMapper, AutoMapperObject>();
        return services;
    }

    public static IServiceCollection AddDcsInfraAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
    {
        if (services.HasRegistered(nameof(AddDcsInfraAutoMapper)))
            return services;

        services.AddAutoMapper(assemblies);
        services.AddSingleton<IObjectMapper, AutoMapperObject>();
        return services;
    }
}