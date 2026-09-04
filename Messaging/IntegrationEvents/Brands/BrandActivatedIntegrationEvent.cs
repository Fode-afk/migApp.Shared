using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Brands;

public sealed record BrandActivatedIntegrationEvent(
    Guid BrandId,
    bool IsAssignable,
    long Version);