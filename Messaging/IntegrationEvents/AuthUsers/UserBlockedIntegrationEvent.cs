using System;

namespace migApp.Shared.Messaging.IntegrationEvents.AuthUsers;

public record UserBlockedIntegrationEvent(string UserId, DateTimeOffset BlockedAt);
