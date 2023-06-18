using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;

namespace CryptoCurrencyQuote.Domain.Services;

public interface ICryptoCurrencyService
{
    Task<CryptoCurrencyQuoteDto?> GetQuotesAsync(string code, IReadOnlyCollection<string> currencies);
}