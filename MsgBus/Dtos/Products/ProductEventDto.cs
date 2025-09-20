using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.MsgBus.Dtos.Product
{
    public class ProductEventDto<T> : BaseEventDto //where T : ProductDtoClass
    {
        public ProductEvents EventType { get; set; }
        public required T Data { get; set; }
    }
}
