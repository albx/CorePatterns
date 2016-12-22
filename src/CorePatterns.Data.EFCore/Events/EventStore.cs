using CorePatterns.Events;
using CorePatterns.Data.EFCore.Events.Mapping;

namespace CorePatterns.Data.EFCore.Events
{
    public class EventStore : IEventStore
    {
        public void Save<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            using(var context = new EventContext())
            {
                var wrapper = EventWrapper.Wrap(@event);
                context.Add(wrapper);

                context.SaveChanges();
            }
        }
    }
}
