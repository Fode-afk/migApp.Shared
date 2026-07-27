using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Categories;

public sealed record CategoryCreatedIntegrationEvent(
    Guid CategoryId,
    string Name,
    string Slug,
    bool IsActive,
    long Version);