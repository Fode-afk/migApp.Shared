using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Vendors
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(VendorPublishedDto), "Published")]
    [JsonDerivedType(typeof(VendorDeletedDto), "Deleted")]
    public abstract class VendorDtoClass
    {
        abstract public string VendorId { get; set; }
    }
}
