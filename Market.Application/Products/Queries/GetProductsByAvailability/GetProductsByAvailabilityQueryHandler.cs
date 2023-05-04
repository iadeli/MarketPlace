using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsByAvailability
{
    public class GetProductsByAvailabilityQueryHandler : IRequestHandler<GetProductsByAvailabilityQuery, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductsByAvailabilityQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Product>> Handle(GetProductsByAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByConditionAsync(p => p.InStock == request.InStock);
            return products;
        }
    }
}
