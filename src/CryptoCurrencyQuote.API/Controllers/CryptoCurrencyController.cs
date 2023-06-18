using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyQuote.API.Controllers;

public class CryptoCurrencyController : BaseApiController
{
    [HttpGet("{code}")]
    public async Task<CryptoCurrencyQuotesDto> Get([FromQuery] string code)
    {
        var query = Mapper.Map<GetCryptoCurrencyQuotesQuery>(code);

        return await Mediator.Send(query);
    }
}