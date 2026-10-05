using migApp.Shared.Enums.Products;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductBlockedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    Guid VendorId,
    bool CanEditContent,
    bool CanEditOperationalData,
    bool IsBlocked,
    ProductStatus ProductStatus,
    string? BlockReason,
    bool IsVisiblePublicly,
    long Version);