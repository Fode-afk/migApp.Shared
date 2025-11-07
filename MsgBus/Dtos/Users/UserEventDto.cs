using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.MsgBus.Dtos.Users
{
    public class UserEventDto<T> : BaseEventDto<UserEventDto<T>>
    {
        public UserEvents EventType { get; set; }
        public required T Data { get; set; }
    }
}
