using migApp.Shared.Enums;

namespace migApp.Shared.EventDtos
{
    public class ImagePublishedDto
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public ContentType ContentType { get; set; }
    }
}
