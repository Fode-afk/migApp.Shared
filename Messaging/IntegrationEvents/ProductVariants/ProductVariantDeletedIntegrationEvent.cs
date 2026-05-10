using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductVariantDeletedIntegrationEvent(Guid ProductVariantId);