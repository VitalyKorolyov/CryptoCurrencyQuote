using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using MediatR;

namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;

public record GetCryptoCurrencyQuotesQuery : IRequest<Result<CryptoCurrencyQuoteDto>>
{
    public required string Code { get; init; }

    //can get only one currency because of free plan
    public readonly IReadOnlyCollection<string> Currencies = new string[]
    {
        "USD", "EUR", "BRL", "GBP", "AUD"
    };
}
