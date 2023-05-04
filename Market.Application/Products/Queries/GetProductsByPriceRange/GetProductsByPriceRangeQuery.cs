using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsByPriceRange
{
    public class GetProductsByPriceRangeQuery : IRequest<List<Product>>
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
