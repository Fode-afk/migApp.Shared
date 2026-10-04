using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Pricing;

public sealed record PriceCreatedIntegrationEvent(
    Guid ProductVariantId,
    Guid ProductId,
    bool HasActivePrice,
    long Version);