using migApp.Shared.Enums.Products;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductUnlockedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    bool CanBeModified,
    bool IsLockedByAdmin,
    ProductStatus ProductStatus,
    bool IsVisiblePublicly,
    long Version);