using CorePatterns.Events;
using System;
using System.Collections.Generic;

namespace CorePatterns.Domain
{
    public abstract class AggregateRoot
    {
        protected ICollection<DomainEvent> _uncommittedEvents = new List<DomainEvent>();

        public Guid Id { get; protected set; }

        public IEnumerable<DomainEvent> UncommitedEvents => _uncommittedEvents;

        public virtual void Apply<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            _uncommittedEvents.Add(@event);
        }

        public virtual void ClearEvents()
        {
            _uncommittedEvents.Clear();
        }
    }
}
