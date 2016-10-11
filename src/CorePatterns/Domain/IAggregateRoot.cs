using CorePatterns.Events;
using System;
using System.Collections.Generic;

namespace CorePatterns.Domain
{
    /// <summary>
    /// Represents a generic aggregate root
    /// </summary>
    public interface IAggregateRoot
    {
        /// <summary>
        /// Get the aggregate's id
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Get the list of uncommited events
        /// </summary>
        IEnumerable<DomainEvent> UncommitedEvents { get; }

        /// <summary>
        /// Add the specified event to the aggregate's uncommited events
        /// </summary>
        /// <typeparam name="TEvent">The event's type</typeparam>
        /// <param name="event">The event to apply</param>
        void Apply<TEvent>(TEvent @event) where TEvent : DomainEvent;

        /// <summary>
        /// Clear all the uncommited events
        /// </summary>
        void ClearEvents();
    }
}
