using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Brands;

public sealed record BrandDeactivatedIntegrationEvent(
    Guid BrandId,
    bool IsAssignable,
    long Version);