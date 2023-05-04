using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetRecommendedProducts
{
    public class GetRecommendedProductsQueryHandler : IRequestHandler<GetRecommendedProductsQuery, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetRecommendedProductsQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Product>> Handle(GetRecommendedProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _productRepository.GetAllQueryable().Where(p => p.CategoryId == request.CategoryId).OrderByDescending(p => p.Popularity).Take(10);
            var products = await Task.Run(() => query.ToList());
            return products;
        }
    }
}
