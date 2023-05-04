using Market.Application.Interfaces;
using Market.Application.Products.Queries.GetProductsBySize;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsByColor
{
    public class GetProductsByColorQueryHandler : IRequestHandler<GetProductsByColorQuery, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductsByColorQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Product>> Handle(GetProductsByColorQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByConditionAsync(p => p.Attributes.Any(a => a.Name == ProductAttributeName.Color.ToString() && a.Value == request.Color));
            return products;
        }
    }
}
