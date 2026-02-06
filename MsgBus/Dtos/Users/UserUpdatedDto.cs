namespace migApp.Shared.MsgBus.Dtos.Users
{
    public class UserUpdatedDto
    {
        public string UserId { get; set; }

        public string Username { get; set; }
        public string AvatarURL { get; set; }
    }
}