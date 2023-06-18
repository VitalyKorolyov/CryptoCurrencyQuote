namespace CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates.Dtos;

public record QuoteDto
{
    public required string Currency { get; init; }
    public decimal Price { get; init; }
}