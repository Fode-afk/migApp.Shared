namespace migApp.Shared.Messaging.IntegrationEvents.Images;

public sealed record ImageDeletedIntegrationEvent(string Id, string Url);
