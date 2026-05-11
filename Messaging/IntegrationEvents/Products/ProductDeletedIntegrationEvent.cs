using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductDeletedIntegrationEvent(Guid ProductId);