using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Pricing;

public sealed record PriceUpdatedIntegrationEvent(
    Guid ProductVariantId,
    bool HasActivePrice,
    long Version);