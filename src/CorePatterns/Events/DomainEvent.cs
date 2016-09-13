using System;

namespace CorePatterns.Events
{
    /// <summary>
    /// Represents a generic domain event
    /// </summary>
    public abstract class DomainEvent
    {
        /// <summary>
        /// Get the aggregate's id which raise the event
        /// </summary>
        public Guid AggregateId { get; }

        /// <summary>
        /// Get the date and time of when the event was fired
        /// </summary>
        public DateTime FiredOn { get; }

        public DomainEvent(Guid aggregateId, DateTime firedOn)
        {
            AggregateId = aggregateId;
            FiredOn = firedOn;
        }
    }
}
