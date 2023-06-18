using AutoMapper;
using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;

namespace CryptoCurrencyQuote.API.Infrastructure.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<string, GetCryptoCurrencyQuotesQuery>()
            .ForMember(t => t.Code, opt => opt.MapFrom(s => s));
    }
}