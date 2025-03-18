using Gravity.Infrastructure.Dapper.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDcsInfraDapper(this IServiceCollection services)
    {
        if (services.HasRegistered(nameof(AddDcsInfraDapper)))
            return services;

        services.TryAddScoped<IAdoExecuterWithQuerierRepository, DapperRepository>();
        services.TryAddScoped<IAdoExecuterRepository, DapperRepository>();
        services.TryAddScoped<IAdoQuerierRepository, DapperRepository>();
        //services.TryAddScoped<IAdoExecuterRepository>(provider => provider.GetRequiredService<IAdoExecuterWithQuerierRepository>());
        //services.TryAddScoped<IAdoQuerierRepository>(provider => provider.GetRequiredService<IAdoExecuterWithQuerierRepository>());
        return services;
    }
}