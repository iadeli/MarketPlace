using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
