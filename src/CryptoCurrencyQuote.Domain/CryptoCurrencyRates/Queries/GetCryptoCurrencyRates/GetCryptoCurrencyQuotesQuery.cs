using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates.Dtos;
using MediatR;

namespace CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;

public record GetCryptoCurrencyQuotesQuery : IRequest<CryptoCurrencyQuoteDto>
{
    public required string Code { get; init; }
}
