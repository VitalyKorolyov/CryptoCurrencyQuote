using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using CryptoCurrencyQuote.Domain.Services;
using MediatR;

namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;

public class GetCryptoCurrencyQuoteQueryHandler 
    : IRequestHandler<GetCryptoCurrencyQuoteQuery, Result<CryptoCurrencyQuoteDto>>
{
    private readonly ICryptoCurrencyService _cryptoCurrencyService;

    public GetCryptoCurrencyQuoteQueryHandler(ICryptoCurrencyService cryptoCurrencyService)
    {
        _cryptoCurrencyService = cryptoCurrencyService ?? throw new ArgumentNullException(nameof(ICryptoCurrencyService));
    }

    public async Task<Result<CryptoCurrencyQuoteDto>> Handle(GetCryptoCurrencyQuoteQuery request,
        CancellationToken cancellationToken)
    {
        return await _cryptoCurrencyService.GetQuotesAsync(request.Code, request.Currencies);
    }
}