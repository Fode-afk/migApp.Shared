using migApp.Shared.Enums.Image;

namespace migApp.Shared.MsgBus.Dtos.Images
{
    public class ImagePublishedDto : ImageDtoClass
    {
        public override string Id { get; set; }
        public string Url { get; set; }
        public ImageType ImageType { get; set; }
    }
}
