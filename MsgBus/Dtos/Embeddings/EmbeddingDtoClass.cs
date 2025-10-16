using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Embeddings
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(EmbeddingPublishedDto), "Published")]
    [JsonDerivedType(typeof(EmbeddingDeletedDto), "Deleted")]
    public abstract class EmbeddingDtoClass
    {
        abstract public string EmbeddingId { get; set; }
    }
}
