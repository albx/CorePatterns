using CorePatterns.Events;
using System;
using System.Collections.Generic;

namespace CorePatterns.AspNetCore.Events
{
    public class EventBus : IEventBus
    {
        public IServiceProvider ServiceProvider { get; }

        public IEventStore EventStore { get; }

        protected IDictionary<Type, IList<Type>> handlerMappings = new Dictionary<Type, IList<Type>>();

        public EventBus(IServiceProvider serviceProvider, IEventStore eventStore)
        {
            ServiceProvider = serviceProvider;
            EventStore = eventStore;
        }

        public void RaiseEvent<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            EventStore.Save(@event);

            var handlers = LoadHandlersForEvent(@event);
            if (handlers != null)
            {
                foreach (var h in handlers)
                {
                    var handlerInstance = ServiceProvider.GetService(h);
                    ((dynamic)handlerInstance).Handle(@event);
                }
            }
        }

        public void RegisterHandler<TEvent, THandler>()
            where TEvent : DomainEvent
            where THandler : IHandleEvent<TEvent>
        {
            var eventType = typeof(TEvent);

            if (!handlerMappings.ContainsKey(eventType))
            {
                handlerMappings.Add(eventType, new List<Type>());
            }

            handlerMappings[eventType].Add(typeof(THandler));
        }

        protected IEnumerable<Type> LoadHandlersForEvent<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            if (!handlerMappings.ContainsKey(@event.GetType()))
            {
                return null;
            }

            return handlerMappings[@event.GetType()];
        }
    }
}
