using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using System;
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
            catch (RpcException) { throw; }
            catch (OperationCanceledException)
            {
                throw new RpcException(new Status(
                    StatusCode.Cancelled,
                    "Client cancelled the request"
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
