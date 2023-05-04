using MediatR;
using System.Reflection;

namespace Market.API.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services, Assembly assembly)
        {
            var handlerInterfaceType = typeof(IRequestHandler<,>);
            var handlerTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType));

            foreach (var handlerType in handlerTypes)
            {
                var interfaces = handlerType.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType);

                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface, handlerType);
                }
            }

            return services;
        }
    }
}
