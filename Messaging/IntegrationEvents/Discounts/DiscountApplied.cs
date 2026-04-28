using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Discounts;

public sealed record DiscountApplied(Guid CorrelationId);