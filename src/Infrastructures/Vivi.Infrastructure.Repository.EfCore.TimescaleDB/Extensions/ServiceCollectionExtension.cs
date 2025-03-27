using Vivi.Infrastructure.Repository.EfCore.TimescaleDB;
using Vivi.Infrastructure.Repository.EfCore.TimescaleDB.Transaction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraEfCoreTimescaleDB(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
    {
        if (services.HasRegistered(nameof(AddInfraEfCoreTimescaleDB)))
            return services;

        services.TryAddScoped<IUnitOfWork, PostgreSQLUnitOfWork<PostgreSQLDbContext>>();
        services.TryAddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
        services.TryAddScoped(typeof(IEfBasicRepository<>), typeof(EfBasicRepository<>));
        services.AddDbContext<DbContext, PostgreSQLDbContext>(optionsBuilder);

        return services;
    }

    public static IServiceCollection AddInfraEfCoreTimescaleDB(this IServiceCollection services, IConfigurationSection section)
    {
        var connectionString = section.GetValue<string>("ConnectionString");
        var serviceInfo = services.GetServiceInfo();

        return AddInfraEfCoreTimescaleDB(services, options =>
        {
            options.UseLowerCaseNamingConvention();
            options.UseNpgsql(connectionString, optionsBuilder =>
            {
                optionsBuilder.MinBatchSize(4)
                              .MigrationsAssembly(serviceInfo?.StartAssembly?.GetName()?.Name?.Replace("ApiService", "Migrations"))
                              .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (env is not null && env.EqualsIgnoreCase("development"))
            {
                options.LogTo(Console.WriteLine, LogLevel.Information)
                       .EnableSensitiveDataLogging()
                       .EnableDetailedErrors();
            }
        });
    }
}
