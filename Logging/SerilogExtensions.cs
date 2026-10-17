using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;

namespace migApp.Shared.Logging;

public static class SerilogExtensions
{
    public static IHostBuilder UseMigAppSerilog(this IHostBuilder host, string serviceName) =>
        host.UseSerilog((ctx, services, config) =>
        {
            var otlpEndpoint = ctx.Configuration["Otlp:Endpoint"]
                ?? throw new InvalidOperationException("Otlp:Endpoint is not configured");

            config
                .ReadFrom.Configuration(ctx.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                .Enrich.WithProperty("ServiceName", serviceName)
                .WriteTo.Async(a => a.Console(new JsonFormatter()),
                    bufferSize: 10000,
                    blockWhenFull: false)
                .WriteTo.Async(a => a.OpenTelemetry(opts =>
                {
                    opts.Endpoint = otlpEndpoint;
                    opts.ResourceAttributes = new Dictionary<string, object>
                    {
                        ["service.name"] = serviceName
                    };
                }),
                    bufferSize: 10000,
                    blockWhenFull: false);
        });
}
