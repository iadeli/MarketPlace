using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsSorted
{
    public class GetProductsSortedQueryHandler : IRequestHandler<GetProductsSortedQuery, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductsSortedQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Product>> Handle(GetProductsSortedQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> query;

            switch (request.SortOption)
            {
                case ProductSortOption.Popularity:
                    query = _productRepository.GetAllQueryable().OrderByDescending(p => p.Popularity);
                    break;
                case ProductSortOption.Rating:
                    query = _productRepository.GetAllQueryable().OrderByDescending(p => p.Rating);
                    break;
                default:
                    throw new ArgumentException($"Invalid sort option: {request.SortOption}", nameof(request.SortOption));
            }

            var products = await Task.Run(() => query.ToList());
            return products;
        }
    }
}
