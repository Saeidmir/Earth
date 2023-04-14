using Earth.Core.Domain.Events;
using System.Reflection;

namespace Earth.Core.Domain.Entities;

/// <summary>
///Pattern of AggregateRoot
/// see full explanation in the following link 
/// https://martinfowler.com/bliki/DDD_Aggregate.html
/// </summary>
public abstract class AggregateRoot : Entity
{
    /// <summary>
    /// The events List
    /// </summary>
    private readonly List<IDomainEvent> _events;
    protected AggregateRoot() => _events = new();

    /// <summary>
    /// Aggregate root constructor 
    /// </summary>
    /// <param name="events">if aggregate exists the parameter send</param>
    public AggregateRoot(IEnumerable<IDomainEvent> events)
    {
        if (events == null || !events.Any()) return;
        foreach (var @event in events)
        {
            Mutate(@event);
        }
    }

    protected void Apply(IDomainEvent @event)
    {
        Mutate(@event);
        AddEvent(@event);
    }

    private void Mutate(IDomainEvent @event)
    {
        var onMethod = this.GetType().GetMethod("On", BindingFlags.Instance | BindingFlags.NonPublic, new Type[] { @event.GetType() });
        onMethod.Invoke(this, new[] { @event });
    }

    /// <summary>
    /// A new event added to the events of this aggregate
    /// the responsiblity of creation and sending the event is on Aggregates 
    /// </summary>
    /// <param name="event"></param>
    protected void AddEvent(IDomainEvent @event) => _events.Add(@event);

    /// <summary>
    /// return a readonly list of aggregate events
    /// </summary>
    /// <returns>Events list</returns>
    public IEnumerable<IDomainEvent> GetEvents() => _events.AsEnumerable();

    /// <summary>
    /// Clear all events
    /// </summary>
    public void ClearEvents() => _events.Clear();
}