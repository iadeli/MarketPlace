using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
