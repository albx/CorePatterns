using CorePatterns.Events;
using Newtonsoft.Json;
using System;

namespace CorePatterns.Data.EFCore.Events.Mapping
{
    public class EventWrapper
    {
        public Guid Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string AggregateType { get; set; }

        public Guid AggregateId { get; set; }

        public string EventType { get; set; }

        public string Payload { get; set; }

        protected EventWrapper() { }

        public static EventWrapper Wrap<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            if (@event == null)
            {
                throw new ArgumentNullException("event");
            }

            var wrapper = new EventWrapper
            {
                Id = Guid.NewGuid(),
                CreatedOn = @event.FiredOn,
                AggregateId = @event.AggregateId,
                AggregateType = @event.AggregateType.ToString(),
                EventType = @event.GetType().ToString(),
                Payload = JsonConvert.SerializeObject(@event)
            };

            return wrapper;
        }
    }
}
