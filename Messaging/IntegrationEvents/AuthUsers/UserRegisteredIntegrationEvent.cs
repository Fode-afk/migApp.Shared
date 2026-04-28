namespace migApp.Shared.Messaging.IntegrationEvents.AuthUsers;

public sealed record UserRegisteredIntegrationEvent(
    string UserId,
    string Username);
