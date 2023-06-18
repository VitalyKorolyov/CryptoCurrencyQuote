using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using MediatR;

namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;

public record GetCryptoCurrencyQuoteQuery : IRequest<Result<CryptoCurrencyQuoteDto>>
{
    public required string Code { get; init; }

    public readonly IReadOnlyCollection<string> Currencies = new string[]
    {
        "USD", "EUR", "BRL", "GBP", "AUD"
    };
}
