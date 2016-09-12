namespace CorePatterns.Events
{
    public interface IEventStore
    {
        void Save<TEvent>(TEvent @event) where TEvent : DomainEvent;
    }
}
