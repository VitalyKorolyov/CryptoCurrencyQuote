using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;

namespace CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;

public interface ICoinMarketCapClient
{
    Task<CryptoCurrencyQuoteEntity?> GetQuoteAsync(string symbol);
}