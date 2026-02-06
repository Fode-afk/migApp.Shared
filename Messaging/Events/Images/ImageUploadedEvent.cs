using migApp.Shared.Enums.Image;

namespace migApp.Shared.Messaging.Events.Images;

public sealed record ImageUploadedEvent(string Id, string Url, ImageType ImageType);
