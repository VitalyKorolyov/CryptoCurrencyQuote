using FluentValidation;
using MediatR;

namespace CryptoCurrencyQuote.Domain.Common.Pipelines;

public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
     where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Any())
        {
            var errorMessage = string.Join("\n", failures.Select(x => x.ErrorMessage));

            var validationError = (TResponse)Activator.CreateInstance(typeof(TResponse));
            validationError.Error = errorMessage;
            return validationError;
        }

        return await next();
    }
}