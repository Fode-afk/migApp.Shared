using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductArchivedIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    bool CanBeModified,
    long Version);