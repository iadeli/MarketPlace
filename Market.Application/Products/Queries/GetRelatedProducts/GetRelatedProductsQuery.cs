using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetRelatedProducts
{
    public class GetRelatedProductsQuery : IRequest<List<Product>>
    {
        public int ProductId { get; set; }
    }
}
