using Microsoft.Extensions.DependencyInjection;

namespace Market.Application.Services
{
    public static class Resolver
    {
        private static IServiceProvider _serviceProvider;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T Resolve<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
