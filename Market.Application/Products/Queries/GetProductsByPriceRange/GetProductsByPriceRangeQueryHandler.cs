using Market.Application.Interfaces;
using Market.Application.Products.Queries.GetProductsByCategory;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsByPriceRange
{
    public class GetProductsByPriceRangeQueryHandler : IRequestHandler<GetProductsByPriceRangeQuery, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductsByPriceRangeQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Product>> Handle(GetProductsByPriceRangeQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByConditionAsync(p => p.Price >= request.MinPrice && p.Price <= request.MaxPrice);
        }
    }
}
