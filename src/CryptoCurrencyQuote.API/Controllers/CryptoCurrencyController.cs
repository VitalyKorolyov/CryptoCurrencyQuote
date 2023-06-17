using CryptoCurrencyQuote.Data.CoinMarketCapServices;
using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyQuote.API.Controllers;

public class CryptoCurrencyController : BaseApiController
{
    private IMediator _mediator;

    public CryptoCurrencyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{code}")]
    public async Task<string> Get(string code)
    {
        var result = await _mediator.Send(new GetCryptoCurrencyRatesQuery { Code = code });

        return "Test";
    }
}