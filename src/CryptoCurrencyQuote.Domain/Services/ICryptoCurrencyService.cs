using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;

namespace CryptoCurrencyQuote.Domain.Services;

public interface ICryptoCurrencyService
{
    Task<CryptoCurrencyQuotesDto?> GetQuotesAsync(string code);
}