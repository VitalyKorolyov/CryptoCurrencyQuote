using AutoMapper;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;

namespace CryptoCurrencyQuote.API.Infrastructure.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<string, GetCryptoCurrencyQuotesQuery>()
            .ForMember(t => t.Code, opt => opt.MapFrom(s => s));

        CreateMap<CryptocurrencyEntity, CryptoCurrencyQuoteDto>()
            .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(t => t.Slug, opt => opt.MapFrom(s => s.Slug))
            .ForMember(t => t.Symbol, opt => opt.MapFrom(s => s.Symbol))
            .ForMember(t => t.Quote, opt => opt.MapFrom(s => s.Quote));

        CreateMap<KeyValuePair<string, QuoteEntity>, QuoteDto>()
            .ForMember(t => t.Currency, opt => opt.MapFrom(s => s.Key))
            .ForMember(t => t.Price, opt => opt.MapFrom(s => s.Value.Price));
    }
}