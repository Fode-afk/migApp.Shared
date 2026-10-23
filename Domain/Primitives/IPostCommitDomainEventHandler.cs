using MediatR;

namespace migApp.Shared.Domain.Primitives;

public interface IPostCommitDomainEventHandler<in T> : INotificationHandler<T>
    where T : IDomainEvent;
