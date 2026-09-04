using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Brands;

public sealed record BrandInfoUpdatedIntegrationEvent(
    Guid BrandId,
    string Name,
    string Slug,
    long Version);