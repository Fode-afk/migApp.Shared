using migApp.Shared.MsgBus.Dtos.Images;
using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Vendors
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(VendorPublishedDto), "Published")]
    [JsonDerivedType(typeof(VendorDeletedDto), "Deleted")]
    public abstract class VendorDtoClass
    {
        abstract public string Id { get; set; }
    }
}
