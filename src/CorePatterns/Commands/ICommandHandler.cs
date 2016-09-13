namespace CorePatterns.Commands
{
    /// <summary>
    /// Represents a command handler
    /// </summary>
    /// <typeparam name="TCommand">The type of the command to handle</typeparam>
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Handle the specified command
        /// </summary>
        /// <param name="command">The command to handle</param>
        void Handle(TCommand command);
    }
}
