using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Orders
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    //[JsonDerivedType(typeof(), "")]
    public abstract class OrderDtoClass
    {
        abstract public string OrderId { get; set; }
    }
}
