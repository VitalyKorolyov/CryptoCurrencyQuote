using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyQuote.API.Controllers;

public class CryptoCurrencyRatesController : BaseApiController
{
    private IMediator _mediator;

    public CryptoCurrencyRatesController(IMediator mediator)
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