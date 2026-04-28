using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Products;

public sealed record ProductCreatedIntegrationEvent(Guid ProductId, Guid VendorId);