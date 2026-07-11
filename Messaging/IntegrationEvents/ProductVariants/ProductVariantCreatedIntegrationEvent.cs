using migApp.Shared.Dtos.ProductVariant;
using System;
using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductVariantCreatedIntegrationEvent(
    Guid ProductVariantId,
    Guid ProductId,
    string Sku,
    DimensionsDto Dimensions,
    WeightDto Weight,
    string Barcode,
    bool HasMainImage,
    List<VariantAttributeDto> Attributes,
    long Version);