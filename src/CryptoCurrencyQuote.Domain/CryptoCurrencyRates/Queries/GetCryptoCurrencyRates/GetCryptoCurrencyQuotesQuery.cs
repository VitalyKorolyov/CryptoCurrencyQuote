using MediatR;

namespace CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;

public record GetCryptoCurrencyQuotesQuery : IRequest<CryptoCurrencyQuotesDto>
{
    public required string Code { get; init; }
}
