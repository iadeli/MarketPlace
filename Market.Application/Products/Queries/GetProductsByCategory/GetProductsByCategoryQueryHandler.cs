using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductsByCategoryQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Product>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByConditionAsync(p => p.Category.Id == request.CategoryId);
        }
    }
}
