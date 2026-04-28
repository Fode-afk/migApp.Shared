using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Pricing;

public sealed record PriceValidated(Guid CorrelationId);