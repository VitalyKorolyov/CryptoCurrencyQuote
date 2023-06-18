using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyQuote.API.Controllers;

public class CryptoCurrencyController : BaseApiController
{
    [HttpGet("{code}")]
    public async Task<Result<CryptoCurrencyQuotesDto>> Get(string code)
    {
        var query = Mapper.Map<GetCryptoCurrencyQuotesQuery>(code);

        return await Mediator.Send(query);
    }
}