namespace CryptoCurrencyQuote.Domain.Common.Settings;

public interface ISettings
{
    public CoinMarketCapSettings CoinMarketCap { get; init; }
}