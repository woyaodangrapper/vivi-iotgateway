using Vivi.Infrastructure.Repository.EfCore.PostgreSQL;
using Vivi.Infrastructure.Repository.EfCore.PostgreSQL.Transaction;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraEfCorePostgreSQL(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
    {
        if (services.HasRegistered(nameof(AddInfraEfCorePostgreSQL)))
            return services;
        services.TryAddScoped<IUnitOfWork, PostgreSQLUnitOfWork<PostgreSQLDbContext>>();
        services.TryAddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
        services.TryAddScoped(typeof(IEfBasicRepository<>), typeof(EfBasicRepository<>));
        services.AddDbContext<DbContext, PostgreSQLDbContext>(optionsBuilder);

        return services;
    }

    public static IServiceCollection AddInfraEfCorePostgreSQL(this IServiceCollection services, IConfigurationSection section)
    {
        var connectionString = section.GetValue<string>("DefaultConnection");
        var serviceInfo = services.GetServiceInfo();
        //NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
        return AddInfraEfCorePostgreSQL(services, options =>
        {
            options.UseSnakeCaseNamingConvention();
            options.UseNpgsql(connectionString, optionsBuilder =>
            {
                optionsBuilder.ConfigureDataSource(dataSource =>
                {
                    dataSource.EnableDynamicJson();// 启用动态JSON支持
                    dataSource.ConfigureJsonOptions(new() { PropertyNameCaseInsensitive = true });
                });
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
