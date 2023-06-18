namespace CryptoCurrencyQuote.Domain.Common;

public record Result
{
    public string? Error { get; set; }

    public Result() { }

    public Result(string? error = default)
    {
        Error = error;
    }
}

public record Result<TValue> : Result
{
    public TValue? Value { get; }

    public bool IsSuccess { get => Error == null; }

    public Result() : base() { }

    private Result(TValue? value, string? error = default) : base(error)
    {
        Value = value;
    }

    public static Result<TValue> Ok(TValue value)
    {
        return new(value);
    }

    public static Result<TValue> BadRequest(string message)
    {
        return new(default, message);
    }
}
