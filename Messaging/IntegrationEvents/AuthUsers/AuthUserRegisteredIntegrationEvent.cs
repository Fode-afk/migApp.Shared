using System;

namespace migApp.Shared.Messaging.IntegrationEvents.AuthUsers;

public sealed record AuthUserRegisteredIntegrationEvent(string UserId, string Username, DateTimeOffset CreatedAt);
