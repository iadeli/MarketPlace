using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
    }
}
