using Vivi.Infrastructure.Redis.Caching;
using Vivi.Infrastructure.Redis.Caching.Configurations;
using Vivi.Infrastructure.Redis.Caching.Core.Interceptor;
using Vivi.Infrastructure.Redis.Caching.Interceptor.Castle;
using Vivi.Infrastructure.Redis.Caching.Provider;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraRedisCaching(this IServiceCollection services, IConfigurationSection redisSection, IConfigurationSection cachingSection)
    {
        if (services.HasRegistered(nameof(AddInfraRedisCaching)))
            return services;

        return services
            .AddInfraRedis(redisSection)
            .Configure<CacheOptions>(cachingSection)
            .AddSingleton<ICacheProvider, DefaultCachingProvider>()
            .AddSingleton<ICachingKeyGenerator, DefaultCachingKeyGenerator>()
            .AddScoped<CachingInterceptor>()
            .AddScoped<CachingAsyncInterceptor>();
    }
}