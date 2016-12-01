using CorePatterns.Commands;
using System;
using System.Collections.Generic;

namespace CorePatterns.AspNetCore.Commands
{
    public class CommandBus : ICommandBus
    {
        public IServiceProvider ServiceProvider { get; }

        protected IDictionary<Type, IList<Type>> handlerMapping = new Dictionary<Type, IList<Type>>();
        protected IDictionary<Type, IList<Type>> asyncHandlerMapping = new Dictionary<Type, IList<Type>>();

        public CommandBus(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public void RegisterAsyncHandler<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : ICommandHandlerAsync<TCommand>
        {
            var commandType = typeof(TCommand);
            if (!asyncHandlerMapping.ContainsKey(commandType))
            {
                asyncHandlerMapping.Add(commandType, new List<Type>());
            }

            asyncHandlerMapping[commandType].Add(typeof(THandler));
        }

        public void RegisterHandler<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : ICommandHandler<TCommand>
        {
            var commandType = typeof(TCommand);
            if (!handlerMapping.ContainsKey(commandType))
            {
                handlerMapping.Add(commandType, new List<Type>());
            }

            handlerMapping[commandType].Add(typeof(THandler));
        }

        public async void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandlers = LoadHandlersForCommand(command);
            var commandAsyncHandler = LoadAsyncHandlersForCommand(command);

            if (commandHandlers != null)
            {
                foreach (var h in commandHandlers)
                {
                    var handlerInstance = ServiceProvider.GetService(h);
                    ((dynamic)handlerInstance).Handle(command);
                }
            }
            
            if (commandAsyncHandler != null)
            {
                foreach (var h in commandAsyncHandler)
                {
                    var handlerInstance = ServiceProvider.GetService(h);
                    await ((dynamic)handlerInstance).Handle(command);
                }
            }
        }

        protected IEnumerable<Type> LoadAsyncHandlersForCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (!asyncHandlerMapping.ContainsKey(command.GetType()))
            {
                return null;
            }

            return asyncHandlerMapping[command.GetType()];
        }

        protected IEnumerable<Type> LoadHandlersForCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (!handlerMapping.ContainsKey(command.GetType()))
            {
                return null;
            }

            return handlerMapping[command.GetType()];
        }
    }
}
