using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Pricing;

public sealed record PriceCreatedIntegrationEvent(
    Guid ProductVariantId,
    bool HasActivePrice,
    long Version);