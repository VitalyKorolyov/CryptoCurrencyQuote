﻿using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;
using Xunit;

namespace CryptoCurrencyQuote.Domain.UnitTests.Queries.GetCryptoCurrencyQuote;

public class GetCryptoCurrencyQuotesQueryValidatorTests
{
    private GetCryptoCurrencyQuotesQueryValidator CreateGetCryptoCurrencyQuotesQueryValidator()
    {
        return new GetCryptoCurrencyQuotesQueryValidator();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Code_Should_ThrowValidationException_When_NullOrEmpty(string code)
    {
        // Arrange
        var validator = CreateGetCryptoCurrencyQuotesQueryValidator();
        var query = new GetCryptoCurrencyQuotesQuery { Code = code };

        // Act
        var result = validator.Validate(query);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == "Code" && error.ErrorMessage == "Code is required.");
    }
}