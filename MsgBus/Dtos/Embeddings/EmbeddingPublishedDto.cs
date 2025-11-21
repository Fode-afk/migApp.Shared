using migApp.Shared.Enums.Embedding;

namespace migApp.Shared.MsgBus.Dtos.Embeddings
{
    public class EmbeddingPublishedDto : EmbeddingDtoClass
    {
        public override string EmbeddingId { get; set; }
        public EmbeddingType Type { get; set; }
        public string Text { get; set; }
    }
}