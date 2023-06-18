using AutoMapper;
using CryptoCurrencyQuote.Domain.Common.Settings;
using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using Microsoft.Extensions.Caching.Memory;

namespace CryptoCurrencyQuote.Domain.Services;

public class CryptoCurrencyService : ICryptoCurrencyService
{
    private readonly IMemoryCache _memoryCache;
    private readonly ISettings _settings;
    private readonly IMapper _mapper;
    private readonly ICoinMarketCapApiClient _coinMarketCapClient;

    public CryptoCurrencyService(ICoinMarketCapApiClient coinMarketCapClient, 
        IMemoryCache memoryCache, ISettings settings, IMapper mapper)
    {
        _coinMarketCapClient = coinMarketCapClient ?? throw new ArgumentNullException(nameof(ICoinMarketCapApiClient));
        _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CryptoCurrencyQuotesDto?> GetQuotesAsync(string code)
    {
        var quotes = await _memoryCache.GetOrCreateAsync(code,
            async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_settings.Cache.Second);
                return await _coinMarketCapClient.GetQuotesAsync(code);
            });

        return _mapper.Map<CryptoCurrencyQuotesDto?>(quotes);
    }
}