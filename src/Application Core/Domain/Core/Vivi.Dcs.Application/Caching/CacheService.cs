using Vivi.Infrastructure.Redis;
using Vivi.Infrastructure.Redis.Caching;
using Vivi.SharedKernel.Const.Caching.Dcs;

namespace Vivi.Dcs.Application.Services.Caching;

public sealed class CacheService : AbstractCacheService, ICachePreheatable
{
    private Lazy<IDistributedLocker> _dictributeLocker;
    private ILogger<CacheService> _logger;

    public CacheService(
        Lazy<ICacheProvider> cacheProvider,
        Lazy<IServiceProvider> serviceProvider,
        Lazy<IDistributedLocker> dictributeLocker,
         ILogger<CacheService> logger)
        : base(cacheProvider, serviceProvider)
    {
        _dictributeLocker = dictributeLocker;
        _logger = logger;
    }

    public override async Task PreheatAsync()
    {
        await AddDcsCacheAsync(new string[] { "hello", "world" });
    }

    internal async Task AddDcsCacheAsync(string[] value)
    {
        var cacheKey = ConcatCacheKey(CachingConsts.DcsTestKey);
        await CacheProvider.Value.SetAsync(cacheKey, value, TimeSpan.FromSeconds(CachingConsts.OneYear));
    }

    internal async Task DeleteDcsCacheAsync(long id)
    {
        var cacheKey = ConcatCacheKey(CachingConsts.DcsTestKey, id.ToString());
        await CacheProvider.Value.RemoveAsync(cacheKey);
    }

    internal async Task<IEnumerable<string>> GetDcsCacheAsync()
    {
        var cacheKey = ConcatCacheKey(CachingConsts.DcsTestKey);
        var cacheValue = await CacheProvider.Value.GetAsync<string[]>(cacheKey);
        return cacheValue.Value;
    }
}