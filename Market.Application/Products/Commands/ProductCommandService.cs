using Market.Application.Interfaces;
using Market.Application.Products.Commands.CreateProduct;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Commands
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly IMediator _mediator;
        public ProductCommandService()
        {
            _mediator = Resolver.Resolve<IMediator>();
        }

        public async Task<int> CreateProductAsync(CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return productId;
        }
    }
}
