using migApp.Shared.Enums;
using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.EventDtos
{
    public class GenericEventDto<T>
    {
        public EventType EventType { get; set; }
        public required ServicesEnum[] Consumers { get; set; }
        public required T Data { get; set; }
    }
}
