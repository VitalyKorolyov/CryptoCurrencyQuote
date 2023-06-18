using AutoMapper;
using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Common.Settings;
using CryptoCurrencyQuote.Domain.Interfaces.Cache;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;

namespace CryptoCurrencyQuote.Domain.Services;

public class CryptoCurrencyService : ICryptoCurrencyService
{
    private readonly ICacheWrapper _memoryCache;
    private readonly ISettings _settings;
    private readonly IMapper _mapper;
    private readonly ICoinMarketCapApiClient _coinMarketCapClient;

    public CryptoCurrencyService(ICoinMarketCapApiClient coinMarketCapClient,
        ICacheWrapper memoryCache, ISettings settings, IMapper mapper)
    {
        _coinMarketCapClient = coinMarketCapClient ?? throw new ArgumentNullException(nameof(ICoinMarketCapApiClient));
        _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<CryptoCurrencyQuotesDto>> GetQuotesAsync(string code, IReadOnlyCollection<string> currencies)
    {
        var quoteResult = await _memoryCache.GetOrCreateAsync(code,
            async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_settings.Cache.Second);
                return await _coinMarketCapClient.GetQuotesAsync(code, currencies);
            });

        if (!quoteResult.IsSuccess)
            return Result<CryptoCurrencyQuotesDto>.BadRequest(quoteResult.Error!);

        var dto = _mapper.Map<CryptoCurrencyQuotesDto>(quoteResult.Value);
        return Result<CryptoCurrencyQuotesDto>.Ok(dto);
    }
}