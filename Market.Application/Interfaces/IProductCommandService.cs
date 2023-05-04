using Market.Application.Products.Commands.CreateProduct;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Interfaces
{
    public interface IProductCommandService
    {
        Task<int> CreateProductAsync(CreateProductCommand product);
    }
}
