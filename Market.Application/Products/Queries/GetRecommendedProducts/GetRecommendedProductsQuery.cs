using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetRecommendedProducts
{
    public class GetRecommendedProductsQuery : IRequest<List<Product>>
    {
        public int CategoryId { get; set; }
    }
}
