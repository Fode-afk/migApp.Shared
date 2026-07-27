using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Categories;

public sealed record CategoryInfoUpdatedIntegrationEvent(
    Guid CategoryId,
    string Name,
    string Slug,
    long Version);