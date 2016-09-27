namespace CorePatterns.Events
{
    /// <summary>
    /// Represents a generic event store
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// Save the specified event
        /// </summary>
        /// <typeparam name="TEvent">The event's type</typeparam>
        /// <param name="event">The event to save</param>
        void Save<TEvent>(TEvent @event) where TEvent : DomainEvent;
    }
}
