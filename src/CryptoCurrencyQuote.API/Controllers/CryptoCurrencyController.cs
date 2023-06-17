using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyQuote.API.Controllers;

public class CryptoCurrencyController : BaseApiController
{
    [HttpGet("{code}")]
    public async Task<string> Get(string code)
    {
        var result = await Mediator.Send(new GetCryptoCurrencyRatesQuery { Code = code });

        return "Test";
    }
}