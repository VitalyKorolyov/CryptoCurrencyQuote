using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using MediatR;

namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;

public record GetCryptoCurrencyQuotesQuery : IRequest<Result<CryptoCurrencyQuotesDto>>
{
    public required string Code { get; init; }

    public IReadOnlyCollection<string> Currencies { get; init; } = new string[]
    {
        "USD", "EUR", "BRL", "GBP", "AUD"
    };
}
