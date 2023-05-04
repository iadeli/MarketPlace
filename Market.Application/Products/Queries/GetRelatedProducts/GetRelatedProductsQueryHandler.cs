using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetRelatedProducts
{
    public class GetRelatedProductsQueryHandler : IRequestHandler<GetRelatedProductsQuery, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetRelatedProductsQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Product>> Handle(GetRelatedProductsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new ArgumentException($"Invalid product ID: {request.ProductId}", nameof(request.ProductId));
            }

            var products = await _productRepository.GetByConditionAsync(p => p.CategoryId == product.CategoryId && p.Id != request.ProductId);
            return products;
        }
    }
}
