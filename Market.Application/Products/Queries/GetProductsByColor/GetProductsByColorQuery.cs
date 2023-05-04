using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductsByColor
{
    public class GetProductsByColorQuery : IRequest<List<Product>>
    {
        public string Color { get; set; }
    }
}
