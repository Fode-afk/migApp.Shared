using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Discounts;

public sealed record DiscountCreated(
    Guid CorrelationId,
    Guid DiscountId, 
    long DiscountAmountInUsdMinor);