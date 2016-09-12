using System.Threading.Tasks;

namespace CorePatterns.Commands
{
    public interface ICommandHandlerAsync<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}
