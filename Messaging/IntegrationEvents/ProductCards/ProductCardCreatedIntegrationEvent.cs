using System;

namespace migApp.Shared.Messaging.IntegrationEvents.ProductCards;

public sealed record ProductCardCreatedIntegrationEvent(Guid ProductCardId, Guid VendorId);