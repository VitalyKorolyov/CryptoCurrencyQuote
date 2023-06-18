using Microsoft.Extensions.Caching.Memory;

namespace CryptoCurrencyQuote.Domain.Interfaces.Cache;

public interface ICacheWrapper
{
    Task<TItem> GetOrCreateAsync<TItem>(object key, Func<ICacheEntry, Task<TItem>> factory);
}