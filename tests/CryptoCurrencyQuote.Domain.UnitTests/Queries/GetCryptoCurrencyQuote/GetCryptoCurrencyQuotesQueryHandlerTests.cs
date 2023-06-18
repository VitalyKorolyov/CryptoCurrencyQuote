using AutoFixture.Xunit2;
using CryptoCurrencyQuote.Domain.Common;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;
using CryptoCurrencyQuote.Domain.Services;
using FakeItEasy;
using Xunit;

namespace CryptoCurrencyQuote.Domain.UnitTests.Queries.GetCryptoCurrencyQuote;

public class GetCryptoCurrencyQuotesQueryHandlerTests
{
    private ICryptoCurrencyService cryptoCurrencyService;

    public GetCryptoCurrencyQuotesQueryHandlerTests()
    {
        cryptoCurrencyService = A.Fake<ICryptoCurrencyService>();
    }

    private GetCryptoCurrencyQuotesQueryHandler CreateGetCryptoCurrencyQuotesQueryHandler()
    {
        return new GetCryptoCurrencyQuotesQueryHandler(cryptoCurrencyService);
    }

    [Theory, AutoData]
    public async Task Handle_Should_ReturnResultFromCryptoCurrencyService(
        GetCryptoCurrencyQuotesQuery query, Result<CryptoCurrencyQuoteDto> expectedResult)
    {
        // Arrange
        A.CallTo(() => cryptoCurrencyService.GetQuotesAsync(query.Code, query.Currencies))
            .Returns(Task.FromResult(expectedResult));
        var handler = CreateGetCryptoCurrencyQuotesQueryHandler();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResult, result);
        A.CallTo(() => cryptoCurrencyService.GetQuotesAsync(query.Code, query.Currencies))
            .MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void Constructor_Should_ThrowArgumentNullException_When_CryptoCurrencyServiceIsNull()
    {
        // Arrange, Act, Assert
        Assert.Throws<ArgumentNullException>(() =>
            new GetCryptoCurrencyQuotesQueryHandler(null));
    }
}
