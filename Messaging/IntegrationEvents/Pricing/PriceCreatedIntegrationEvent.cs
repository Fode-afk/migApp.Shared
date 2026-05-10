using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Pricing;

public sealed record PriceCreatedIntegrationEvent(Guid ProductId, Guid VendorId, decimal Price);