using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductVariantImageRemovedIntegrationEvent(
    Guid ProductVariantId,
    bool HasMainImage,
    long Version);