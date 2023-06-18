using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;
using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyQuote.API.Controllers;

public class CryptoCurrencyController : BaseApiController
{
    [HttpGet("{code}")]
    public async Task<CryptoCurrencyQuoteDto> Get(string code)
    {
        var query = Mapper.Map<GetCryptoCurrencyQuotesQuery>(code);

        return await Mediator.Send(query);
    }
}