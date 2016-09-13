using CorePatterns.Events;
using System;
using System.Collections.Generic;

namespace CorePatterns.Domain
{
    /// <summary>
    /// Represents an aggregate root
    /// </summary>
    public abstract class AggregateRoot
    {
        protected ICollection<DomainEvent> _uncommittedEvents = new List<DomainEvent>();

        /// <summary>
        /// Get or set the aggregate's id
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Get the list of uncommited events
        /// </summary>
        public IEnumerable<DomainEvent> UncommitedEvents => _uncommittedEvents;

        /// <summary>
        /// Add the specified event to the aggregate's uncommited events
        /// </summary>
        /// <typeparam name="TEvent">The event's type</typeparam>
        /// <param name="event">The event to apply</param>
        public virtual void Apply<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            if (@event == null)
            {
                throw new ArgumentNullException("event");
            }

            _uncommittedEvents.Add(@event);
        }

        /// <summary>
        /// Clear all the uncommited events
        /// </summary>
        public virtual void ClearEvents()
        {
            _uncommittedEvents.Clear();
        }
    }
}
