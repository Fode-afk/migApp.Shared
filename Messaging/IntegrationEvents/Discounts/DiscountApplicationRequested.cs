using migApp.Shared.Enums.Discounts;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Discounts;

public sealed record DiscountApplicationRequested(
    Guid CorrelationId,
    Guid ProductId,
    Guid DiscountId,
    DiscountType DiscountType,
    long MoneyInUsdMinor,
    DateTimeOffset Start,
    DateTimeOffset End);