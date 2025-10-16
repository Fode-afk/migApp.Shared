using migApp.Shared.MsgBus.Enums;
namespace migApp.Shared.MsgBus.Dtos.Embeddings
{
    public class EmbeddingEventDto<T> : BaseEventDto<EmbeddingEventDto<T>>
    {
        public EmbeddingEvents EventType { get; set; }
        public required T Data { get; set; }
    }
}
