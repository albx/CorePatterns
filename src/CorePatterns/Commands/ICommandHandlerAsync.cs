using System.Threading.Tasks;

namespace CorePatterns.Commands
{
    /// <summary>
    /// Represents a command handler which handle the command in an async way
    /// </summary>
    /// <typeparam name="TCommand">The type of the command to handle</typeparam>
    public interface ICommandHandlerAsync<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Handle the specified command
        /// </summary>
        /// <param name="command">The command to handle</param>
        /// <returns></returns>
        Task Handle(TCommand command);
    }
}
