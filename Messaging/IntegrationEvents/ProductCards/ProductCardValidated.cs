using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductCards;

public sealed record ProductCardValidated(Guid CorrelationId);