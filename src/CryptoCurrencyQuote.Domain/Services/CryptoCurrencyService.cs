using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using Microsoft.Extensions.Caching.Memory;

namespace CryptoCurrencyQuote.Domain.Services;

public class CryptoCurrencyService : ICryptoCurrencyService
{
    private readonly IMemoryCache _memoryCache;
    private readonly ICoinMarketCapApiClient _coinMarketCapClient;

    public CryptoCurrencyService(ICoinMarketCapApiClient coinMarketCapClient, IMemoryCache memoryCache)
    {
        _coinMarketCapClient = coinMarketCapClient ?? throw new ArgumentNullException(nameof(ICoinMarketCapApiClient));
        _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
    }



}