using System.Threading;
using System.Threading.Tasks;

namespace migApp.Shared.MsgBus
{
    public interface IEventProcessor
    {
        Task ProcessEventAsync(string message, CancellationToken ct);
    }
}
