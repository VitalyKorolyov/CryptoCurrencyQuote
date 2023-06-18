using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;

namespace CryptoCurrencyQuote.Domain.Services;

public interface ICryptoCurrencyService
{
    Task<Result<CryptoCurrencyQuoteDto>> GetQuotesAsync(string code, IReadOnlyCollection<string> currencies);
}