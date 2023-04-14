using Earth.Core.Domain.Events;

namespace Earth.Core.Contracts.ApplicationService.Events;

public interface IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent   
{
    Task Handle(TDomainEvent Event);
}
