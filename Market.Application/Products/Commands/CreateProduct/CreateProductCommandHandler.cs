using Market.Application.Interfaces;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IRepository<Product> _productRepository;

        public CreateProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId
            };
            await _productRepository.AddAsync(product);
            return product.Id;
        }
    }
}
