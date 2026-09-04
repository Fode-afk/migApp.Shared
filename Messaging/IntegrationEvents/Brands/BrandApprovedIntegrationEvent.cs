using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Brands;

public sealed record BrandApprovedIntegrationEvent(
    Guid BrandId,
    bool IsAssignable,
    long Version);