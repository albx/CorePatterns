using CorePatterns.AspNetCore.Commands;
using CorePatterns.AspNetCore.Events;
using CorePatterns.Commands;
using CorePatterns.Events;
using Microsoft.Extensions.DependencyInjection;

namespace CorePatterns.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommandBus(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<ICommandBus>(new CommandBus(serviceProvider));

            return services;
        }

        public static ICommandBus CommandBus(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetService<ICommandBus>();
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<IEventBus>(new EventBus(serviceProvider, serviceProvider.GetService<IEventStore>()));

            return services;
        }

        public static IEventBus EventBus(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetService<IEventBus>();
        }
    }
}
