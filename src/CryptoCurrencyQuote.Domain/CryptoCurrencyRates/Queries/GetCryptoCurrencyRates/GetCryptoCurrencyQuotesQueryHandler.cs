using AutoMapper;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using MediatR;

namespace CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;

public class GetCryptoCurrencyQuotesQueryHandler : IRequestHandler<GetCryptoCurrencyQuotesQuery, CryptoCurrencyQuotesDto>
{
    private readonly IMapper _mapper;
    private readonly ICoinMarketCapApiClient _coinMarketCapClient;

    public GetCryptoCurrencyQuotesQueryHandler(IMapper mapper, ICoinMarketCapApiClient coinMarketCapClient)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        _coinMarketCapClient = coinMarketCapClient ?? throw new ArgumentNullException(nameof(ICoinMarketCapApiClient));
    }

    public async Task<CryptoCurrencyQuotesDto> Handle(GetCryptoCurrencyQuotesQuery request, 
        CancellationToken cancellationToken)
    {
        var response = await _coinMarketCapClient.GetQuotesAsync(request.Code);

        return new CryptoCurrencyQuotesDto();
    }
}