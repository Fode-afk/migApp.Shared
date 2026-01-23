using migApp.Shared.MsgBus.Dtos.Users;
using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.AuthUsers
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(UserUpdatedDto), "Registered")]
    public abstract class AuthUserDtoClass
    {
        abstract public string UserId { get; set; }
    }
}
