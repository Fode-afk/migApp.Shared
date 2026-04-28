using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Pricing;

public sealed record BasePriceRequested(Guid CorrelationId, Guid ProductId);