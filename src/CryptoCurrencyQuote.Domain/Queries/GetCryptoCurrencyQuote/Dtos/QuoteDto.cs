﻿namespace CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote.Dtos;

public record QuoteDto
{
    public required string Currency { get; init; }
    public decimal Price { get; init; }
}