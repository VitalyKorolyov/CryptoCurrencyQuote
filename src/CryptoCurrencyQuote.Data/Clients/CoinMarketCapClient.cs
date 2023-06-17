using CryptoCurrencyQuote.Domain.Common.Settings;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;
using System.Net.Http.Json;

namespace CryptoCurrencyQuote.Data.CoinMarketCapServices;

public class CoinMarketCapClient : ICoinMarketCapClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ISettings _settings;

    public CoinMarketCapClient(IHttpClientFactory httpClientFactory, ISettings settings)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(IHttpClientFactory));
        _settings = settings ?? throw new ArgumentNullException(nameof(ISettings)); 
    }

    public async Task<CryptoCurrencyQuoteEntity?> GetQuoteAsync(string symbol)
    {
        var client = _httpClientFactory.CreateClient();

        string url = _settings.CoinMarketCap.ApiUrl + "/v2/cryptocurrency/quotes/latest";

        client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _settings.CoinMarketCap.ApiKey);
        client.DefaultRequestHeaders.Add("Accepts", "application/json");

        var response = await client.GetAsync(url + $"?symbol={symbol}&convert=USD");

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<CryptoCurrencyQuoteEntity>();

        return null;
    }
}