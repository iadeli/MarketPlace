using Market.Application.Interfaces;
using Market.Application.Products.Queries.GetProductsSorted;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsBySize
{
    public class GetProductsBySizeQueryHandler : IRequestHandler<GetProductsBySizeQuery, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductsBySizeQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Product>> Handle(GetProductsBySizeQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByConditionAsync(p => p.Attributes.Any(a => a.Name == ProductAttributeName.Size.ToString() && a.Value == request.Size));
            return products;
        }
    }
}
