using System;

namespace CorePatterns.Events
{
    public abstract class DomainEvent
    {
        public Guid AggregateId { get; }

        public DateTime FiredOn { get; }

        public DomainEvent(Guid aggregateId, DateTime firedOn)
        {
            AggregateId = aggregateId;
            FiredOn = firedOn;
        }
    }
}
