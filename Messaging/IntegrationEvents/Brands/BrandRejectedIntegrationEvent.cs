using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Brands;

public sealed record BrandRejectedIntegrationEvent(
    Guid BrandId,
    bool IsAssignable,
    long Version);