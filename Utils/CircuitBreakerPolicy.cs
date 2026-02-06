using Grpc.Core;
using Microsoft.Extensions.Logging;
using Polly;
using System;

namespace migApp.Shared.Utils;

public static class CircuitBreakerPolicy
{
    public static IAsyncPolicy GetCircuitBreakerPolicy(ILogger logger)
    {
        return Policy
            .Handle<RpcException>(ex => ex.StatusCode == StatusCode.Unavailable
                             || ex.StatusCode == StatusCode.DeadlineExceeded
                             || ex.StatusCode == StatusCode.Internal)
            .AdvancedCircuitBreakerAsync(
                failureThreshold: 0.2,
                samplingDuration: TimeSpan.FromSeconds(120),
                minimumThroughput: 20,
                durationOfBreak: TimeSpan.FromSeconds(60),
                onBreak: (ex, breakDelay) =>
                {
                    logger.LogWarning("Circuit opened for {Delay}s due to: {Message}",
                        breakDelay.TotalSeconds, ex.Message);
                },
                onReset: () => logger.LogInformation("Circuit closed — connection restored"),
                onHalfOpen: () => logger.LogInformation("Circuit half-open — testing connection")
            );
    }
}
