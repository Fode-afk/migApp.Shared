using migApp.Shared.MsgBus.Dtos.Product;
using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Images
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(ImagePublishedDto), "Published")]
    [JsonDerivedType(typeof(ImagePublishedDto), "Deleted")]
    public abstract class ImageDtoClass
    {
        abstract public string Id { get; set; }
    }
}
