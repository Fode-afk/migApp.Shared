using migApp.Shared.Dtos.ProductVariant;
using System;
using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductVariantImagesReorderedIntegrationEvent(
    Guid ProductVariantId,
    Guid ProductId,
    List<ProductVariantImageDto> Images,
    long Version);