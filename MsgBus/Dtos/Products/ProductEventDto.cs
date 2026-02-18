using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.MsgBus.Dtos.Products
{
    public class ProductEventDto<T> : BaseEventDto<ProductEventDto<T>>
    {
        public ProductEvents EventType { get; set; }
        public required T Data { get; set; }
    }
}
