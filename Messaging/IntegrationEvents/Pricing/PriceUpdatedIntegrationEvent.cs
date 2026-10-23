using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Pricing;

public sealed record PriceUpdatedIntegrationEvent(
    Guid ProductVariantId,
    long CurrentPriceMinor,
    string Currency,
    long Version);