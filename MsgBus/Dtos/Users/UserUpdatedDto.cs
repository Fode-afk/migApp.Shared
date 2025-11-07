namespace migApp.Shared.MsgBus.Dtos.Users
{
    public class UserUpdatedDto : UserDtoClass
    {
        public override string UserId { get; set; }

        public string Username { get; set; }
        public string AvatarURL { get; set; }
    }
}