using CryptoCurrencyQuote.Domain.Services;
using MediatR;

namespace CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;

public class GetCryptoCurrencyQuotesQueryHandler : IRequestHandler<GetCryptoCurrencyQuotesQuery, CryptoCurrencyQuotesDto>
{
    private readonly ICryptoCurrencyService _cryptoCurrencyService;

    public GetCryptoCurrencyQuotesQueryHandler(ICryptoCurrencyService cryptoCurrencyService)
    {
        _cryptoCurrencyService = cryptoCurrencyService ?? throw new ArgumentNullException(nameof(ICryptoCurrencyService));
    }

    public async Task<CryptoCurrencyQuotesDto?> Handle(GetCryptoCurrencyQuotesQuery request, 
        CancellationToken cancellationToken)
    {
        return await _cryptoCurrencyService.GetQuotesAsync(request.Code);
    }
}