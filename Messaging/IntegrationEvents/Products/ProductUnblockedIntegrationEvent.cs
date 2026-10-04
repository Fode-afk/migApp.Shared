using migApp.Shared.Enums.Products;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductUnblockedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    Guid VendorId,
    bool CanBeModified,
    bool IsBlocked,
    ProductStatus ProductStatus,
    string? BlockReason,
    bool IsVisiblePublicly,
    long Version);