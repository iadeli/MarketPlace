using Market.Application.Interfaces;
using Market.Application.Products.Queries.GetCategories;
using Market.Application.Products.Queries.GetProduct;
using Market.Application.Products.Queries.GetProducts;
using Market.Application.Products.Queries.GetProductsByAvailability;
using Market.Application.Products.Queries.GetProductsByBrand;
using Market.Application.Products.Queries.GetProductsByCategory;
using Market.Application.Products.Queries.GetProductsByColor;
using Market.Application.Products.Queries.GetProductsByPriceRange;
using Market.Application.Products.Queries.GetProductsBySize;
using Market.Application.Products.Queries.GetProductsSorted;
using Market.Application.Products.Queries.GetProductsSortedByDate;
using Market.Application.Products.Queries.GetRecommendedProducts;
using Market.Application.Products.Queries.GetRelatedProducts;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly IMediator _mediator;
        public ProductQueryService()
        {
            _mediator = Resolver.Resolve<IMediator>();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var query = new GetCategoriesQuery();
            return await _mediator.Send(query);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var query = new GetProductQuery { Id = id };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var query = new GetProductsQuery();
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetProductsByAvailabilityAsync(bool inStock)
        {
            var query = new GetProductsByAvailabilityQuery() { InStock = inStock };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetProductsByBrandAsync(int brandId)
        {
            var query = new GetProductsByBrandQuery { BrandId = brandId };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            var query = new GetProductsByCategoryQuery { CategoryId = categoryId };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetProductsByColorAsync(string color)
        {
            var query = new GetProductsByColorQuery { Color = color };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            var query = new GetProductsByPriceRangeQuery { MinPrice = minPrice, MaxPrice = maxPrice };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetProductsBySizeAsync(string size)
        {
            var query = new GetProductsBySizeQuery { Size = size };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetProductsSortedAsync(ProductSortOption sortOption)
        {
            var query = new GetProductsSortedQuery() { SortOption = sortOption };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetProductsSortedByDateAsync()
        {
            var query = new GetProductsSortedByDateQuery() { };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetRecommendedProductsAsync(int categoryId)
        {
            var query = new GetRecommendedProductsQuery() { };
            return await _mediator.Send(query);
        }

        public async Task<List<Product>> GetRelatedProductsAsync(int productId)
        {
            var query = new GetRelatedProductsQuery() { };
            return await _mediator.Send(query);
        }
    }
}
