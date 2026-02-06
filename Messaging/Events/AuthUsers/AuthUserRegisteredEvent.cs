using System;

namespace migApp.Shared.Messaging.Events.AuthUsers;

public sealed record AuthUserRegisteredEvent(string UserId, string Username, DateTimeOffset CreatedAt);
