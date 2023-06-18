using CryptoCurrencyQuote.Domain.Interfaces.Cache;
using Microsoft.Extensions.Caching.Memory;

namespace CryptoCurrencyQuote.Data.Cache;

public class MemoryCacheWrapper : ICacheWrapper
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
