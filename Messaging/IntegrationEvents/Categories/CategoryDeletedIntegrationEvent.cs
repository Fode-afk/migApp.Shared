using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Categories;

public sealed record CategoryDeletedIntegrationEvent(Guid CategoryId);