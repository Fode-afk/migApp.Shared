using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Brands;

public sealed record BrandCreatedIntegrationEvent(
    Guid BrandId,
    string Name,
    string Slug,
    bool IsAssignable,
    long Version);