using migApp.Shared.Enums.Products;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductPublishRejectedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    Guid VendorId,
    bool CanBeModified,
    ProductStatus ProductStatus,
    string? RejectionReason,
    bool IsVisiblePublicly,
    long Version);