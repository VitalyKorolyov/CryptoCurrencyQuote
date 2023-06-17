namespace CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;

public record CryptoCurrencyQuoteEntity
{
    public required Dictionary<string, List<CryptocurrencyEntity>> Data { get; init; }
}

public record CryptocurrencyEntity
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Symbol { get; init; }
    public required string Slug { get; init; }
    public required Dictionary<string, QuoteEntity> Quote { get; init; }
}

public record QuoteEntity
{
    public decimal Price { get; init; }
    public decimal Volume_24h { get; init; }
    public decimal Volume_Change_24h { get; init; }
    public decimal Percent_Change_1h { get; init; }
    public decimal Percent_Change_24h { get; init; }
    public decimal Percent_Change_7d { get; init; }
    public decimal Percent_Change_30d { get; init; }
    public decimal Percent_Change_60d { get; init; }
    public decimal Percent_Change_90d { get; init; }
    public decimal Market_Cap { get; init; }
    public decimal Market_Cap_Dominance { get; init; }
    public decimal Fully_Diluted_Market_Cap { get; init; }
    public DateTime Last_Updated { get; init; }
}
