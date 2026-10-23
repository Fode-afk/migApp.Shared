using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Pricing;

public sealed record PriceCreatedIntegrationEvent(
    Guid ProductVariantId,
    long CurrentPriceMinor,
    string Currency,
    long Version);