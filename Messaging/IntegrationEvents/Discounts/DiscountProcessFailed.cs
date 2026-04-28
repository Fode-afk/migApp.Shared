using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Discounts;

public record DiscountProcessFailed(Guid CorrelationId, string Reason);