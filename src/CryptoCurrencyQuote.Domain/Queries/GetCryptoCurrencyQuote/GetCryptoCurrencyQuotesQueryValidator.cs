using FluentValidation;

namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;

public class GetCryptoCurrencyQuotesQueryValidator : AbstractValidator<GetCryptoCurrencyQuotesQuery>
{
    //TODO here we have to check if a code is exist as well
    public GetCryptoCurrencyQuotesQueryValidator()
    {
        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
            .WithMessage("Code is required.");
    }
}