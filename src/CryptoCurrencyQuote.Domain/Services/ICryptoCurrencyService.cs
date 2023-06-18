using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates.Dtos;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;

namespace CryptoCurrencyQuote.Domain.Services;

public interface ICryptoCurrencyService
{
    Task<CryptoCurrencyQuoteDto?> GetQuotesAsync(string code);
}