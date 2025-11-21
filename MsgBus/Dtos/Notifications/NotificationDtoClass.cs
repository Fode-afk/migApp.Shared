using migApp.Shared.MsgBus.Dtos.Orders;
using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Notifications
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(NotificationPublishedDto), "Published")]
    public abstract class NotificationDtoClass
    {
        public abstract string ReceiverId { get; set; }
        public abstract string Message { get; set; }
    }
}
