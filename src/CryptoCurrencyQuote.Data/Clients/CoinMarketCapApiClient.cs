using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Common.Settings;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;
using System.Net.Http.Json;

namespace CryptoCurrencyQuote.Data.CoinMarketCapServices;

public class CoinMarketCapApiClient : ICoinMarketCapApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ISettings _settings;

    public CoinMarketCapApiClient(IHttpClientFactory httpClientFactory, ISettings settings)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(IHttpClientFactory));
        _settings = settings ?? throw new ArgumentNullException(nameof(ISettings)); 
    }

    public async Task<Result<CryptocurrencyEntity>> GetQuotesAsync(string symbol, IReadOnlyCollection<string> currencies)
    {
        var client = _httpClientFactory.CreateClient();

        string url = _settings.CoinMarketCap.ApiUrl + "/v2/cryptocurrency/quotes/latest";

        client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _settings.CoinMarketCap.ApiKey);
        client.DefaultRequestHeaders.Add("Accepts", "application/json");

        List<CryptocurrencyEntity> quote = new();
        foreach (var currency in currencies)
        {
            var response = await client.GetAsync(url + $"?symbol={symbol}&convert={currency}");

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return Result<CryptocurrencyEntity>.BadRequest(message);
            }

            var result = await response.Content.ReadFromJsonAsync<CryptoCurrencyQuotesEntity>();
            quote.AddRange(result!.Data.Values.SelectMany(x => x));
        }

        if (quote.Count == 0) 
            return Result<CryptocurrencyEntity>.BadRequest("Cryptocurrency data not found.");

        var cryptoCurrencyInfo = quote.First();

        return Result<CryptocurrencyEntity>.Ok(new()
        {
            Id = cryptoCurrencyInfo.Id,
            Name = cryptoCurrencyInfo.Name,
            Symbol = cryptoCurrencyInfo.Symbol,
            Slug = cryptoCurrencyInfo.Slug,
            Quote = quote.SelectMany(x => x.Quote)
                .GroupBy(x => x.Key).ToDictionary(x => x.First().Key, y => y.First().Value)
        });
    }
}