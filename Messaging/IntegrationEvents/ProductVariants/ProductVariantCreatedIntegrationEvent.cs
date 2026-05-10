using System;
using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductVariants;

public sealed record ProductVariantCreatedIntegrationEvent(
    Guid ProductVariantId, 
    Guid ProductId,
    bool HasMainImage,
    long Version,
    List<ProductVariantCharacteristicValue> CharacteristicValues);

public sealed record ProductVariantCharacteristicValue(
    Guid ProductVariantId,
    Guid CharacteristicId,
    string Value);