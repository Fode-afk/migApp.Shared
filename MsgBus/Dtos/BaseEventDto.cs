using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.MsgBus.Dtos
{
    public class BaseEventDto<T>
    {
        public EventCategory Category { get; set; }
        public ServicesEnum[] Consumers { get; set; }
        public T Event { get; set; }
        public string EventType { get; set; } = string.Empty;
    }
}
