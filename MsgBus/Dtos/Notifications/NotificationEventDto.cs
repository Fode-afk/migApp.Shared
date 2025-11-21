using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.MsgBus.Dtos.Notifications
{
    public class NotificationEventDto<T> : BaseEventDto<NotificationEventDto<T>>
    {
        public NotificationEvents EventType { get; set; }
        public required T Data { get; set; }
    }
}
