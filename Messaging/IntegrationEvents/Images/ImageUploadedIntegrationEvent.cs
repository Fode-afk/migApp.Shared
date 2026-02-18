using migApp.Shared.Enums.Image;

namespace migApp.Shared.Messaging.IntegrationEvents.Images;

public sealed record ImageUploadedIntegrationEvent(string Id, string Url, ImageType ImageType);
