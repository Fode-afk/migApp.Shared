using System;

namespace migApp.Shared.Messaging.Events.AuthUsers;

public record UserBlockedEvent(string UserId, DateTimeOffset BlockedAt);
