using Market.Application.Interfaces;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetCategoriesQueryHandler()
        {
            _productRepository = Resolver.Resolve<IRepository<Product>>();
        }

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _productRepository.GetAllQueryable()
                .GroupBy(p => p.Category)
                .Select(g => g.Key);
            
            return await Task.Run(() => query.ToList());
        }
    }
}
