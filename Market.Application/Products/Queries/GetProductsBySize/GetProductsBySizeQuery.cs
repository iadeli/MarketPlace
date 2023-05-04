using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsBySize
{
    public class GetProductsBySizeQuery : IRequest<List<Product>>
    {
        public string Size { get; set; }
    }
}
