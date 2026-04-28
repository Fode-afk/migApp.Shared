using migApp.Shared.Enums.Discounts;
using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Discounts;

public sealed record CreateDiscountStarted(
    Guid CorrelationId,
    Guid ProductCardId,
    Guid ProductId,
    Guid VendorId,
    long MoneyMinor,
    string Currency,
    DiscountType Type,
    DateTimeOffset Start,
    DateTimeOffset End);