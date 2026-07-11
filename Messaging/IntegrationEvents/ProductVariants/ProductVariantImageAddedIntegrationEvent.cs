using migApp.Shared.Dtos.ProductVariant;
using System;
using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductVariantImageAddedIntegrationEvent(
    Guid ProductVariantId,
    Guid ProductId,
    List<ProductVariantImageDto> Images,
    bool HasMainImage,
    long Version);