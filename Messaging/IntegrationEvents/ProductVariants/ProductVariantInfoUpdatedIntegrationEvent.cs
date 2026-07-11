using migApp.Shared.Dtos.ProductVariant;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductVariantInfoUpdatedIntegrationEvent(
    Guid ProductVariantId,
    Guid ProductId,
    string Sku,
    DimensionsDto Dimensions,
    WeightDto Weight,
    string Barcode,
    long Version);