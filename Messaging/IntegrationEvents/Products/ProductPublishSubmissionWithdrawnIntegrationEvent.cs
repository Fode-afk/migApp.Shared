using migApp.Shared.Enums.Products;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductPublishSubmissionWithdrawnIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    Guid VendorId,
    bool CanBeModified,
    ProductStatus ProductStatus,
    bool IsVisiblePublicly,
    long Version);