using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Brands;

public sealed record BrandDeletedIntegrationEvent(Guid BrandId);
