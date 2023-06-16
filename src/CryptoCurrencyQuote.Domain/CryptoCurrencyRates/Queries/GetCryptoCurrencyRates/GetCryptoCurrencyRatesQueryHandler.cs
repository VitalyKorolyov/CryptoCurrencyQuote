using AutoMapper;
using MediatR;

namespace CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;

public class GetCryptoCurrencyRatesQueryHandler : IRequestHandler<GetCryptoCurrencyRatesQuery, CryptoCurrencyRatesDto>
{
    private readonly IMapper _mapper;

    public GetCryptoCurrencyRatesQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CryptoCurrencyRatesDto> Handle(GetCryptoCurrencyRatesQuery request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}