using System;

namespace migApp.Shared.Messaging.IntegrationEvents.Vendors;

public sealed record VendorCreatedIntegrationEvent(
    Guid VendorId,
    bool IsActive,
    long Version);