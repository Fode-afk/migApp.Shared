using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductImageRemovedIntegrationEvent(
    Guid ProductVariantId,
    bool HasMainImage,
    long Version);