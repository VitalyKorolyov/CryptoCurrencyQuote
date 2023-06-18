﻿using AutoMapper;
using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Common.Settings;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
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

    public async Task<Result<CryptoCurrencyQuoteDto>> GetQuotesAsync(string code, IReadOnlyCollection<string> currencies)
    {
        var quoteResult = await _memoryCache.GetOrCreateAsync(code,
            async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_settings.Cache.Second);
                return await _coinMarketCapClient.GetQuotesAsync(code, currencies);
            });

        if (quoteResult!.IsSuccess)
        {
            var dto = _mapper.Map<CryptoCurrencyQuoteDto>(quoteResult!.Value);
            return Result<CryptoCurrencyQuoteDto>.Ok(dto);
        }
        else return Result<CryptoCurrencyQuoteDto>.BadRequest(quoteResult.Error!);
    }
}