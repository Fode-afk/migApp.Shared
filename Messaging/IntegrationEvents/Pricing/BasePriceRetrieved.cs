using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Pricing;

public sealed record BasePriceRetrieved(Guid CorrelationId, long BasePriceInUsdMinor);