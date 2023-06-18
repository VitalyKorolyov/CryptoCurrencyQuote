using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
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