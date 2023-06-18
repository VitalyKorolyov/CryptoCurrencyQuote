using Microsoft.Extensions.Caching.Memory;

namespace CryptoCurrencyQuote.Domain.Common.Cache;

public interface IMemoryCacheWrapper
{
    Task<TItem> GetOrCreateAsync<TItem>(object key, Func<ICacheEntry, Task<TItem>> factory);
}