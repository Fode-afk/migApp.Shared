using MediatR;

namespace migApp.Shared.Domain.Primitives;

public interface IPreCommitDomainEventHandler<in T> : INotificationHandler<T>
    where T : IDomainEvent;
