using migApp.Shared.MsgBus.Enums;
namespace migApp.Shared.MsgBus.Dtos.Images
{
    public class ImageEventDto<T> : BaseEventDto //where T : ImageDtoClass
    {
        public ImageEvents EventType { get; set; }
        public required T Data { get; set; }
    }
}
