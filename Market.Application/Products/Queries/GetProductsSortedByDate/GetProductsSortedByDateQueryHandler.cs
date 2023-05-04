using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsSortedByDate
{
    public class GetProductsSortedByDateQueryHandler : IRequestHandler<GetProductsSortedByDateQuery, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductsSortedByDateQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Product>> Handle(GetProductsSortedByDateQuery request, CancellationToken cancellationToken)
        {
            var query = _productRepository.GetAllQueryable().OrderByDescending(p => p.DateAdded);
            var products = await Task.Run(() => query.ToList());
            return products;
        }
    }
}
