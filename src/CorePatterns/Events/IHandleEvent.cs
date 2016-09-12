namespace CorePatterns.Events
{
    public interface IHandleEvent<TEvent> where TEvent : DomainEvent
    {
        void Handle(TEvent @event);
    }
}
