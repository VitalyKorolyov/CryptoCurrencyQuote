namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;

public record CryptoCurrencyQuotesDto
{
    public required string Name { get; init; }
    public required string Symbol { get; init; }
    public required string Slug { get; init; }
    public required IReadOnlyCollection<QuoteDto> Quotes { get; init; }
}