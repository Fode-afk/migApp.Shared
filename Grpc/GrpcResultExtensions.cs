using Grpc.Core;
using migApp.Shared.returnTypes;

namespace migApp.Shared.Grpc
{
    public static class GrpcResultExtensions
    {
        public static void ThrowIfFailure(this IResult result)
        {
            if (result.IsFailure)
                throw new RpcException(result.ErrorType.ToStatus(result.Message));
        }

        public static T ThrowIfFailure<T>(this IResult<T> result)
        {
            if (result.IsFailure)
                throw new RpcException(result.ErrorType.ToStatus(result.Message));

            return result.Value;
        }

        private static Status ToStatus(this ErrorType errorType, string message)
        {
            return errorType switch
            {
                ErrorType.NotFound => new Status(StatusCode.NotFound, message),
                ErrorType.InvalidArgument => new Status(StatusCode.InvalidArgument, message),
                ErrorType.AlreadyExists => new Status(StatusCode.AlreadyExists, message),
                ErrorType.Unauthenticated => new Status(StatusCode.Unauthenticated, message),
                ErrorType.Internal => new Status(StatusCode.Internal, message),
                _ => new Status(StatusCode.Unknown, message)
            };
        }
    }
}
