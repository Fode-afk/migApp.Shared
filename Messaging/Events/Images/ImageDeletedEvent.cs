namespace migApp.Shared.Messaging.Events.Images;

public sealed record ImageDeletedEvent(string Id, string Url);
