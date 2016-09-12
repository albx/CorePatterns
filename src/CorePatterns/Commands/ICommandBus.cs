namespace CorePatterns.Commands
{
    public interface ICommandBus
    {
        void RegisterHandler<TCommand, THandler>() where TCommand : ICommand where THandler : ICommandHandler<TCommand>;

        void RegisterAsyncHandler<TCommand, THandler>() where TCommand : ICommand where THandler : ICommandHandlerAsync<TCommand>;

        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
