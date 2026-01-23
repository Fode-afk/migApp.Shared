using System;

namespace migApp.Shared.MsgBus.Dtos.AuthUsers
{
    public class AuthUserRegisteredDto : AuthUserDtoClass
    {
        public override string UserId { get; set; }
        public string Username { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}