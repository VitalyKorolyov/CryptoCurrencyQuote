using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;

namespace CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;

public interface ICoinMarketCapApiClient
{
    Task<CryptoCurrencyQuotesEntity?> GetQuotesAsync(string symbol);
}