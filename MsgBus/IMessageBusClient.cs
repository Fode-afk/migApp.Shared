using migApp.Shared.MsgBus.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace migApp.Shared.MsgBus
{
    public interface IMessageBusClient
    {
        Task InitAsync();
        Task PublishRawAsync(string payload, string eventType, IEnumerable<ServicesEnum> consumers, CancellationToken ct);
        ValueTask Dispose();
    }
}
