using migApp.Shared.Enums;

namespace migApp.Shared.EventDtos
{
    public class GenericEventDto<T>
    {
        public EventType EventType { get; set; }
        public required ServicesEnum[] Consumers { get; set; }
        public required T Data { get; set; }
    }
}
