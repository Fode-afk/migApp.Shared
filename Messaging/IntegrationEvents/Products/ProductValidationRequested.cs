using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductValidationRequested(
    Guid CorrelationId,
    Guid VendorId,
    Guid ProductCardId,
    Guid ProductId);