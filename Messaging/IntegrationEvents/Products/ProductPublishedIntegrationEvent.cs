using migApp.Shared.Enums.Products;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductPublishedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    Guid VendorId,
    bool CanBeModified,
    ProductStatus ProductStatus,
    DateTimeOffset? ApprovedAt,
    bool IsVisiblePublicly,
    long Version);