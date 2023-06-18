namespace CryptoCurrencyQuote.Domain.Common.Settings;

public record Settings : ISettings
{
    public required CoinMarketCapSettings CoinMarketCap { get; init; }
    public required CacheSettings Cache { get; init; }
}

public record CoinMarketCapSettings
{
    public required string ApiKey { get; init; }
    public required string ApiUrl { get; init; }
}

public record CacheSettings
{
    public required int Second { get; init; }
}