namespace CorePatterns.Events
{
    /// <summary>
    /// Represents a generic event handler
    /// </summary>
    /// <typeparam name="TEvent">The type of the event to handle</typeparam>
    public interface IHandleEvent<TEvent> where TEvent : DomainEvent
    {
        /// <summary>
        /// Handle the specified event
        /// </summary>
        /// <param name="event">The event to handle</param>
        void Handle(TEvent @event);
    }
}
