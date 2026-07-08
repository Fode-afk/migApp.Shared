using migApp.Shared.Enums.Products;
using System;
using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductArchivedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    bool CanBeModified,
    ProductStatus ProductStatus,
    List<SuspensionReason> SuspensionReasons,
    long Version);