namespace migApp.Shared.MsgBus.Dtos.Images
{
    public class ImageDeletedDto : ImageDtoClass
    {
        public override string Id { get; set; }
        public string Url { get; set; }
    }
}
