using migApp.Shared.MsgBus.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace migApp.Shared.MsgBus
{
    public interface IMessageBusClient
    {
        Task InitAsync();
        Task PublishEventAsync<TPayload, TEventEnum>(TPayload payload, TEventEnum eventType, ServicesEnum[] consumers, CancellationToken ct) where TEventEnum : Enum;
        ValueTask Dispose();
    }
}
