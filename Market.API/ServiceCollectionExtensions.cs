using Market.API.Extensions;
using Market.Application.Interfaces;
using Market.Application.Products.Commands;
using Market.Application.Products.Queries;
using Market.Application.Products.Queries.GetProducts;
using Market.Application.Services;
using Market.Domain;
using Market.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Market.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAssemblyOf<IRepository<Product>>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddHandlers(typeof(GetProductsQuery).GetTypeInfo().Assembly);
            services.AddAssemblyOf<IProductQueryService>();
            return services;
        }

        private static IServiceCollection AddAssemblyOf<T>(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(T))
                .AddClasses(classes => classes.AssignableTo(typeof(T)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
