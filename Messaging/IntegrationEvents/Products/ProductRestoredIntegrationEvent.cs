using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductRestoredIntegrationEvent(
    Guid ProductId,
    Guid CategoryId,
    bool CanBeModified,
    long Version);