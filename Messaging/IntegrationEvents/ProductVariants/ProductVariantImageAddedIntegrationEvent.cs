using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductVariantImageAddedIntegrationEvent(
    Guid ProductVariantId,
    bool HasMainImage,
    long Version);