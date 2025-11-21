using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.MsgBus.Dtos.Orders
{
    public class OrderEventDto<T> : BaseEventDto<OrderEventDto<T>>
    {
        public OrderEvents EventType { get; set; }
        public required T Data { get; set; }
    }
}
