namespace CryptoCurrencyQuote.Domain.Common.Settings;

public interface ISettings
{
    CoinMarketCapSettings CoinMarketCap { get; init; }
    CacheSettings Cache { get; init; }
}