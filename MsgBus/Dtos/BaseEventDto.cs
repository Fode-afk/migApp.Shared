using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.MsgBus.Dtos
{
    public class BaseEventDto
    {
        public EventCategory Category { get; set; }
        public required ServicesEnum[] Consumers { get; set; }
    }
}
