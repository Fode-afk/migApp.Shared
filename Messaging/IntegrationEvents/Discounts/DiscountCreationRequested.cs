using migApp.Shared.Enums.Discounts;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Discounts;

public sealed record DiscountCreationRequested(
    Guid CorrelationId,
    long MoneyMinor,
    string Currency,
    DiscountType Type,
    long BasePriceInUsdMinor,
    DateTimeOffset Start,
    DateTimeOffset End);