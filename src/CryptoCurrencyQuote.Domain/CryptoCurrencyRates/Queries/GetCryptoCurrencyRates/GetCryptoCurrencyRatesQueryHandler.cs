using AutoMapper;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using MediatR;

namespace CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;

public class GetCryptoCurrencyRatesQueryHandler : IRequestHandler<GetCryptoCurrencyRatesQuery, CryptoCurrencyRatesDto>
{
    private readonly IMapper _mapper;
    private readonly ICoinMarketCapClient _coinMarketCapClient;

    public GetCryptoCurrencyRatesQueryHandler(IMapper mapper, ICoinMarketCapClient coinMarketCapClient)
    {
        _mapper = mapper;
        _coinMarketCapClient = coinMarketCapClient;
    }

    public async Task<CryptoCurrencyRatesDto> Handle(GetCryptoCurrencyRatesQuery request, 
        CancellationToken cancellationToken)
    {
        var response = await _coinMarketCapClient.GetQuoteAsync(request.Code);

        return new CryptoCurrencyRatesDto();
    }
}