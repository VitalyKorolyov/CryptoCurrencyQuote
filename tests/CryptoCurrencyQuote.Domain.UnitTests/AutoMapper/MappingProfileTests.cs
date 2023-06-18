using AutoFixture.Xunit2;
using AutoMapper;
using CryptoCurrencyQuote.API.Infrastructure.AutoMapper;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using Xunit;

namespace CryptoCurrencyQuote.Domain.UnitTests.AutoMapper;

public class MappingProfileTests
{
    private readonly IMapper _mapper;

    public MappingProfileTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Theory, AutoData]
    public void Map_CryptocurrencyEntity_On_CryptoCurrencyQuoteDto_Ok(CryptocurrencyEntity entity)
    {
        // Act
        var result = _mapper.Map<CryptoCurrencyQuoteDto>(entity);

        // Assert
        Assert.Equal(result.Name, entity.Name);
        Assert.Equal(result.Symbol, entity.Symbol);
        Assert.Equal(result.Slug, entity.Slug);

        foreach ((KeyValuePair<string, QuoteEntity> expected, QuoteDto res) in entity.Quote.Zip(result.Quote))
        {
            Assert.Equal(expected.Value.Price, res.Price);
            Assert.Equal(expected.Key, res.Currency);
        }
    }
}