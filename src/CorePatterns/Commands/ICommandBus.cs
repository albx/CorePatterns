namespace CorePatterns.Commands
{
    /// <summary>
    /// Represents a generic command bus
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        /// Register the command to its handler
        /// </summary>
        /// <typeparam name="TCommand">The command's type</typeparam>
        /// <typeparam name="THandler">The handler's type</typeparam>
        void RegisterHandler<TCommand, THandler>() where TCommand : ICommand where THandler : ICommandHandler<TCommand>;

        /// <summary>
        /// Register the command to its async handler
        /// </summary>
        /// <typeparam name="TCommand">The command's type</typeparam>
        /// <typeparam name="THandler">The handler's type</typeparam>
        void RegisterAsyncHandler<TCommand, THandler>() where TCommand : ICommand where THandler : ICommandHandlerAsync<TCommand>;

        /// <summary>
        /// Dispatch the specified command
        /// </summary>
        /// <typeparam name="TCommand">The command's type</typeparam>
        /// <param name="command">The command to send</param>
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
