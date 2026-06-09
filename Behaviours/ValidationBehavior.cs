using FluentValidation;
using MediatR;
using migApp.Shared.Domain.Errors;
using migApp.Shared.Results;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace migApp.Shared.Behaviours;

public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TResponse : IResult
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next(cancellationToken);

        var validationResults = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(request, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (failures.Count == 0)
            return await next(cancellationToken);

        var errorsDictionary = failures
            .GroupBy(f => f.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(f => f.ErrorCode).ToArray());

        var error = Error.Validation(
            CommonErrorCodes.ValidationFailed,
            new Dictionary<string, object>
            {
                ["Errors"] = errorsDictionary
            });

        return CreateFailure<TResponse>(error);
    }

    private static TResponse CreateFailure<TResponse>(Error error)
        where TResponse : IResult
    {
        var responseType = typeof(TResponse);

        if (!responseType.IsGenericType)
        {
            var failMethod = typeof(Result).GetMethod(nameof(Result.Fail), BindingFlags.Public | BindingFlags.Static)!;
            var result = failMethod.Invoke(null, [error])!;
            return (TResponse)result;
        }

        var genericArg = responseType.GetGenericArguments()[0];
        var resultType = typeof(Result<>).MakeGenericType(genericArg);

        var failGenericMethod = resultType.GetMethod(nameof(Result<>.Fail),
            BindingFlags.Public | BindingFlags.Static)!;

        var failResult = failGenericMethod.Invoke(null, [error])!;
        return (TResponse)failResult;
    }
}