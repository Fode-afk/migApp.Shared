using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Images
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(ImagePublishedDto), "Published")]
    [JsonDerivedType(typeof(ImageDeletedDto), "Deleted")]
    [JsonDerivedType(typeof(List<ImageDeletedDto>), "ListDeleted")]
    public abstract class ImageDtoClass
    {
        abstract public string Id { get; set; }
    }
}
