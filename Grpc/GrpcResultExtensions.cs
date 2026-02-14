using Grpc.Core;
using migApp.Shared.Results;
using System.Text.Json;

namespace migApp.Shared.Grpc;

public static class GrpcResultExtensions
{
    public static void ThrowIfFailure(this IResult result)
    {
        if (result.IsFailure)
        {
            var metadata = BuildMetadata(result.Error);
            throw new RpcException(result.Error.Type.ToStatus(result.Error.Code), metadata);
        }
    }

    public static T ThrowIfFailure<T>(this IResult<T> result)
    {
        if (result.IsFailure)
        {
            var metadata = BuildMetadata(result.Error);
            throw new RpcException(result.Error.Type.ToStatus(result.Error.Code), metadata);
        }

        return result.Value;
    }

    private static Status ToStatus(this ErrorType errorType, string code)
    {
        return errorType switch
        {
            ErrorType.NotFound => new Status(StatusCode.NotFound, code),
            ErrorType.InvalidArgument => new Status(StatusCode.InvalidArgument, code),
            ErrorType.AlreadyExists => new Status(StatusCode.AlreadyExists, code),
            ErrorType.Unauthenticated => new Status(StatusCode.Unauthenticated, code),
            ErrorType.Internal => new Status(StatusCode.Internal, code),
            _ => new Status(StatusCode.Unknown, code)
        };
    }

    private static Metadata BuildMetadata(Error error)
    {
        var metadata = new Metadata
        {
            { "error-code", error.Code }
        };

        if (error.Type == ErrorType.InvalidArgument &&
            error.Metadata != null &&
            error.Metadata.TryGetValue("Errors", out var validationErrors))
        {
            var json = JsonSerializer.Serialize(validationErrors);
            metadata.Add("validation-errors-bin", System.Text.Encoding.UTF8.GetBytes(json));
        }

        return metadata;
    }
}
