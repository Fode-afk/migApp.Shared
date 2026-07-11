using migApp.Shared.Enums.Products;
using System;
using System.Collections.Generic;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductUnsuspendedIntegrationEvent(
    Guid ProductId,
    ProductStatus ProductStatus,
    List<SuspensionReason> SuspensionReasons,
    bool IsVisiblePublicly,
    long Version);
