using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsByBrand
{
    public class GetProductsByBrandQueryHandler : IRequestHandler<GetProductsByBrandQuery, IEnumerable<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductsByBrandQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByConditionAsync(p => p.Brand.Id == request.BrandId);
        }
    }
}
