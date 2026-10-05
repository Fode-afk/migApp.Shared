using migApp.Shared.Enums.Products;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductCreatedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    Guid VendorId,
    Guid BrandId,
    string Name,
    string Slug,
    string Description,
    string ShortDescription,
    string SeoTitle,
    string SeoDescription,
    string SeoKeywords,
    ProductStatus ProductStatus,
    bool CanEditContent,
    bool CanEditOperationalData,
    bool IsVisiblePublicly,
    long Version);