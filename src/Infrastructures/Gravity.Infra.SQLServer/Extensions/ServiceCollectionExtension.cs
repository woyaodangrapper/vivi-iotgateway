using SanGu.Infrastructure.Repository.EfCore.SqlServer;
using SanGu.Infrastructure.Repository.EfCore.SqlServer.Transaction;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDcsInfraEfCoreSQLServer(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
    {
        if (services.HasRegistered(nameof(AddDcsInfraEfCoreSQLServer)))
            return services;

        services.TryAddScoped<IUnitOfWork, SqlServerUnitOfWork<SqlServerDbContext>>();
        services.TryAddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
        services.TryAddScoped(typeof(IEfBasicRepository<>), typeof(EfBasicRepository<>));
        services.AddDbContext<DbContext, SqlServerDbContext>(optionsBuilder);

        return services;
    }

    public static IServiceCollection AddDcsInfraEfCoreSQLServer(this IServiceCollection services, IConfigurationSection sqlServerSection)
    {
        var connectionString = sqlServerSection.GetValue<string>("ConnectionString");
        var serviceInfo = services.GetServiceInfo();

        return AddDcsInfraEfCoreSQLServer(services, options =>
        {
            options.UseLowerCaseNamingConvention();
            options.UseSqlServer(connectionString, optionsBuilder =>
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