using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Categories;

public sealed record CategoryDeactivatedIntegrationEvent(
    Guid CategoryId,
    bool IsActive,
    long Version);