using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Categories;

public sealed record CategoryActivatedIntegrationEvent(
    Guid CategoryId, 
    bool IsActive, 
    long Version);
