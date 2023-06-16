using MediatR;

namespace CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;

public record GetCryptoCurrencyRatesQuery : IRequest<CryptoCurrencyRatesDto>
{
    public required string Code { get; init; }
}
