using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductVariantForceDeletedIntegrationEvent(
    Guid ProductVariantId,
    Guid ProductId);
