using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductInfoUpdatedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    Guid BrandId,
    string Name,
    string Slug,
    string Description,
    string ShortDescription,
    string SeoTitle,
    string SeoDescription,
    string SeoKeywords,
    bool CanBeModified,
    long Version);