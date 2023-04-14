using Earth.Core.Domain.Events;

namespace Earth.Core.Contracts.ApplicationService.Events;

public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent;
}
