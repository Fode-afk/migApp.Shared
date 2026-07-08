using migApp.Shared.Dtos.Product;
using System;
using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductVariantAddedIntegrationEvent(
    Guid ProductId,
    List<ProductAttributeDto> Attributes,
    long Version);