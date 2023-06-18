namespace CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates.Dtos;

public record CryptoCurrencyQuoteDto
{
    public required string Name { get; init; }
    public required string Symbol { get; init; }
    public required string Slug { get; init; }
    public required IReadOnlyCollection<QuoteDto> Quote { get; init; }
}