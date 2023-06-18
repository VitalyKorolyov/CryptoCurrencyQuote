using AutoMapper;
using CryptoCurrencyQuote.Domain.Common.Settings;
using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using CryptoCurrencyQuote.Domain.Services;
using Microsoft.Extensions.Caching.Memory;
using Xunit;
using FakeItEasy;
using AutoFixture.Xunit2;
using CryptoCurrencyQuote.Domain.Interfaces.Cache;

namespace CryptoCurrencyQuote.Domain.UnitTests.Services;

public class CryptoCurrencyServiceTests
{
    private readonly ICacheWrapper _memoryCache;
    private readonly ISettings _settings;
    private readonly IMapper _mapper;
    private readonly ICoinMarketCapApiClient _coinMarketCapClient;
    private readonly CryptoCurrencyService _cryptoCurrencyService;

    public CryptoCurrencyServiceTests()
    {
        _memoryCache = A.Fake<ICacheWrapper>();
        _settings = A.Fake<ISettings>();
        _mapper = A.Fake<IMapper>();
        _coinMarketCapClient = A.Fake<ICoinMarketCapApiClient>();

        _cryptoCurrencyService = new CryptoCurrencyService(_coinMarketCapClient,
            _memoryCache, _settings, _mapper);
    }

    [Fact]
    public void Constructor_Should_ThrowArgumentNullException_When_CoinMarketCapClientIsNull()
    {
        // Arrange, Act, Assert
        Assert.Throws<ArgumentNullException>(() =>
            new CryptoCurrencyService(null, _memoryCache, _settings, _mapper));
    }

    [Fact]
    public void Constructor_Should_ThrowArgumentNullException_When_MemoryCacheIsNull()
    {
        // Arrange, Act, Assert
        Assert.Throws<ArgumentNullException>(() =>
            new CryptoCurrencyService(_coinMarketCapClient, null, _settings, _mapper));
    }

    [Fact]
    public void Constructor_Should_ThrowArgumentNullException_When_SettingsIsNull()
    {
        // Arrange, Act, Assert
        Assert.Throws<ArgumentNullException>(() =>
            new CryptoCurrencyService(_coinMarketCapClient, _memoryCache, null, _mapper));
    }

    [Fact]
    public void Constructor_Should_ThrowArgumentNullException_When_MapperIsNull()
    {
        // Arrange, Act, Assert
        Assert.Throws<ArgumentNullException>(() =>
            new CryptoCurrencyService(_coinMarketCapClient, _memoryCache, _settings, null));
    }

    [Theory, AutoData]
    public async Task GetQuotesAsync_ShouldReturnOkResult_WhenQuoteResultIsSuccess(
        List<string> currencies, string code, CryptoCurrencyQuotesDto expectedDto, CryptocurrencyEntity entity)
    {
        // Arrange
        var quoteResult = Result<CryptocurrencyEntity>.Ok(entity);

        A.CallTo(() => _mapper.Map<CryptoCurrencyQuotesDto>(quoteResult.Value))
            .Returns(expectedDto);
        A.CallTo(() => _memoryCache.GetOrCreateAsync(code, A<Func<ICacheEntry, Task<Result<CryptocurrencyEntity>>>>.Ignored))
            .Returns(quoteResult);

        // Act
        var result = await _cryptoCurrencyService.GetQuotesAsync(code, currencies);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(expectedDto, result.Value);
        A.CallTo(() => _mapper.Map<CryptoCurrencyQuotesDto>(quoteResult.Value)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _memoryCache.GetOrCreateAsync(code, A<Func<ICacheEntry, Task<Result<CryptocurrencyEntity>>>>.Ignored)).MustHaveHappenedOnceExactly();
    }

    [Theory, AutoData]
    public async Task GetQuotesAsync_ShouldReturnBadRequestResult_WhenQuoteResultIsNotSuccess(
        List<string> currencies, string code)
    {
        // Arrange
        var errorMessage = "Failed to retrieve quotes.";
        var quoteResult = Result<CryptocurrencyEntity>.BadRequest(errorMessage);

        A.CallTo(() => _memoryCache.GetOrCreateAsync(code, A<Func<ICacheEntry, Task<Result<CryptocurrencyEntity>>>>.Ignored))
            .Returns(quoteResult);

        // Act
        var result = await _cryptoCurrencyService.GetQuotesAsync(code, currencies);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(errorMessage, result.Error);
        A.CallTo(() => _mapper.Map<CryptoCurrencyQuotesDto>(quoteResult.Value)).MustNotHaveHappened();
        A.CallTo(() => _memoryCache.GetOrCreateAsync(code, A<Func<ICacheEntry, Task<Result<CryptocurrencyEntity>>>>.Ignored)).MustHaveHappenedOnceExactly();
    }
}