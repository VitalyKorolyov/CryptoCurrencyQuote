using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using CryptoCurrencyQuote.Domain.Services;
using MediatR;

namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;

public class GetCryptoCurrencyQuotesQueryHandler : IRequestHandler<GetCryptoCurrencyQuotesQuery, CryptoCurrencyQuoteDto>
{
    private readonly ICryptoCurrencyService _cryptoCurrencyService;

    public GetCryptoCurrencyQuotesQueryHandler(ICryptoCurrencyService cryptoCurrencyService)
    {
        _cryptoCurrencyService = cryptoCurrencyService ?? throw new ArgumentNullException(nameof(ICryptoCurrencyService));
    }

    public async Task<CryptoCurrencyQuoteDto?> Handle(GetCryptoCurrencyQuotesQuery request,
        CancellationToken cancellationToken)
    {
        return await _cryptoCurrencyService.GetQuotesAsync(request.Code, request.Currencies);
    }
}