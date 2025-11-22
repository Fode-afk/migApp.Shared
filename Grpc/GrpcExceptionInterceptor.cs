using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace migApp.Shared.Grpc
{
    public class GrpcExceptionInterceptor(ILogger<GrpcExceptionInterceptor> logger) : Interceptor
    {
        private readonly ILogger<GrpcExceptionInterceptor> _logger = logger;

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "NOT_FOUND: {Message}", ex.Message);

                throw new RpcException(new Status(
                    StatusCode.NotFound,
                    ex.Message
                ));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "INVALID_ARGUMENT: {Message}", ex.Message);

                throw new RpcException(new Status(
                    StatusCode.InvalidArgument,
                    ex.Message
                ));
            }
            catch (DuplicateNameException ex)
            {
                _logger.LogWarning(ex, "ALREADY_EXISTS: {Message}", ex.Message);

                throw new RpcException(new Status(
                    StatusCode.AlreadyExists,
                    ex.Message
                ));
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "UNAUTHORIZED: {Message}", ex.Message);

                throw new RpcException(new Status(
                    StatusCode.PermissionDenied,
                    ex.Message
                ));
            }
            catch (AuthenticationException ex)
            {
                _logger.LogWarning(ex, "UNAUTHENTICATED: {Message}", ex.Message);

                throw new RpcException(new Status(
                    StatusCode.Unauthenticated,
                    ex.Message
                ));
            }
            catch (InvalidProgramException ex)
            {
                _logger.LogWarning(ex, "FAILED_PRECONDITION: {Message}", ex.Message);

                throw new RpcException(new Status(
                    StatusCode.FailedPrecondition,
                    ex.Message
                ));
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "INVALID_ARGUMENT: {Message}", ex.Message);

                throw new RpcException(new Status(
                    StatusCode.InvalidArgument,
                    ex.Message
                ));
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "INVALID_ARGUMENT: {Message}", ex.Message);

                throw new RpcException(new Status(
                    StatusCode.InvalidArgument,
                    ex.Message
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "INTERNAL_SERVER_ERROR");

                throw new RpcException(new Status(
                    StatusCode.Internal,
                    "Internal server error"
                ));
            }
        }
    }
}
