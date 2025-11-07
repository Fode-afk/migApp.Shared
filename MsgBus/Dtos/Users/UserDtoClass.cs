using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Users
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(UserUpdatedDto), "Updated")]
    [JsonDerivedType(typeof(UserDeletedDto), "Deleted")]
    public abstract class UserDtoClass
    {
        abstract public string UserId { get; set; }
    }
}
