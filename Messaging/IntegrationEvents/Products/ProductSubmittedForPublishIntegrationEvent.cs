using migApp.Shared.Enums.Products;
using System;
using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductSubmittedForPublishIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    Guid VendorId,
    bool CanEditContent,
    bool CanEditOperationalData,
    ProductStatus ProductStatus,
    List<SuspensionReason> SuspensionReasons,
    string? RejectionReason,
    DateTimeOffset? SubmittedForPublishApprovalAt,
    bool IsVisiblePublicly,
    long Version);