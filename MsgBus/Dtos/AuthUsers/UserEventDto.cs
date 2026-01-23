using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.MsgBus.Dtos.AuthUsers
{
    public class AuthUserEventDto<T> : BaseEventDto<AuthUserEventDto<T>>
    {
        public AuthUserEvents EventType { get; set; }
        public required T Data { get; set; }
    }
}
