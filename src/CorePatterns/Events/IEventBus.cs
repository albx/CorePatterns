namespace CorePatterns.Events
{
    public interface IEventBus
    {
        void RegisterHandler<TEvent, THandler>() where TEvent : DomainEvent where THandler : IHandleEvent<TEvent>;

        void RaiseEvent<TEvent>(TEvent @event) where TEvent : DomainEvent;
    }
}
