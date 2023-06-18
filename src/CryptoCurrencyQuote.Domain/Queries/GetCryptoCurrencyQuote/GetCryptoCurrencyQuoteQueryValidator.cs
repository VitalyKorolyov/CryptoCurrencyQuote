using FluentValidation;

namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;

public class GetCryptoCurrencyQuoteQueryValidator : AbstractValidator<GetCryptoCurrencyQuoteQuery>
{
    //TODO here we have to check if a code is exist as well
    public GetCryptoCurrencyQuoteQueryValidator()
    {
        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
            .WithMessage("Code is required.");
    }
}