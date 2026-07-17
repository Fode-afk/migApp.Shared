using migApp.Shared.Enums.Products;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductLockedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    Guid VendorId,
    bool CanBeModified,
    bool IsLockedByAdmin,
    ProductStatus ProductStatus,
    bool IsVisiblePublicly,
    long Version);