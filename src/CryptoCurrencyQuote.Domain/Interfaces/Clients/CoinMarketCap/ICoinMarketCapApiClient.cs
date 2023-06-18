using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;

namespace CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;

public interface ICoinMarketCapApiClient
{
    Task<Result<CryptocurrencyEntity>> GetQuotesAsync(string symbol, IReadOnlyCollection<string> currencies);
}