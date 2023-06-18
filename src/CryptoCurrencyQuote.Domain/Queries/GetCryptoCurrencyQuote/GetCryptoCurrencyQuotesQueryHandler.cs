using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using CryptoCurrencyQuote.Domain.Services;
using MediatR;

namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;

public class GetCryptoCurrencyQuotesQueryHandler 
    : IRequestHandler<GetCryptoCurrencyQuotesQuery, Result<CryptoCurrencyQuotesDto>>
{
    private readonly ICryptoCurrencyService _cryptoCurrencyService;

    public GetCryptoCurrencyQuotesQueryHandler(ICryptoCurrencyService cryptoCurrencyService)
    {
        _cryptoCurrencyService = cryptoCurrencyService ?? throw new ArgumentNullException(nameof(ICryptoCurrencyService));
    }

    public async Task<Result<CryptoCurrencyQuotesDto>> Handle(GetCryptoCurrencyQuotesQuery request,
        CancellationToken cancellationToken)
    {
        return await _cryptoCurrencyService.GetQuotesAsync(request.Code, request.Currencies);
    }
}