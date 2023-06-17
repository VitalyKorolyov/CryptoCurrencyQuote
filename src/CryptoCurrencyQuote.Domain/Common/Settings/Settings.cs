namespace CryptoCurrencyQuote.Domain.Common.Settings;

public record Settings : ISettings
{
    public required CoinMarketCapSettings CoinMarketCap { get; init; }
}

public record CoinMarketCapSettings
{
    public required string ApiKey { get; set; }
    public required string ApiUrl { get; set; }
}