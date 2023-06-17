using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap.Models;
using System.Net.Http.Json;

namespace CryptoCurrencyQuote.Data.CoinMarketCapServices;

public class CoinMarketCapClient : ICoinMarketCapClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CoinMarketCapClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private const string ApiKey = "d1a05340-b794-460a-8489-eec810632b3c";
    private const string ApiUrl = "https://pro-api.coinmarketcap.com/v2/cryptocurrency/quotes/latest";

    public async Task<CryptoCurrencyQuoteEntity?> GetQuoteAsync(string symbol)
    {
        var client = _httpClientFactory.CreateClient();

        client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", ApiKey);
        client.DefaultRequestHeaders.Add("Accepts", "application/json");

        var response = await client.GetAsync(ApiUrl + $"?symbol={symbol}&convert=USD");

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<CryptoCurrencyQuoteEntity>();

        return null;
    }
}