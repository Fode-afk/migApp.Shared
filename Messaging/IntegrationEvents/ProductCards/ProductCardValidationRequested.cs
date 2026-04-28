using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductCards;

public sealed record ProductCardValidationRequested(
    Guid CorrelationId,
    Guid ProductCardId,
    Guid VendorId);