using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductImageAddedIntegrationEvent(
    Guid ProductVariantId,
    bool HasMainImage,
    long Version);