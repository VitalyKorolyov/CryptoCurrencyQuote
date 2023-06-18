using Microsoft.Extensions.Caching.Memory;

namespace CryptoCurrencyQuote.Domain.Common.Cache;

public class MemoryCacheWrapper : IMemoryCacheWrapper
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheWrapper(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
    }

    public Task<TItem> GetOrCreateAsync<TItem>(object key, Func<ICacheEntry, Task<TItem>> factory)
    {
        return _memoryCache.GetOrCreateAsync(key, factory)!;
    }
}
