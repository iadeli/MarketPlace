using Market.Application.Interfaces;
using Market.Application.Products.Commands.CreateProduct;
using Market.Application.Products.Queries.GetProduct;
using Market.Application.Services;
using Market.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductCommandService _commandService;
        private readonly IProductQueryService _queryService;
        public ProductsController()
        {
            _commandService = Resolver.Resolve<IProductCommandService>();
            _queryService = Resolver.Resolve<IProductQueryService>();
        }

        #region Command

        [HttpPost]
        public async Task<ActionResult<Product>> CreateAsync(CreateProductCommand command)
        {
            int productId = await _commandService.CreateProductAsync(command);
            return CreatedAtAction(nameof(GetProductsById), new { id = productId }, command);
        }

        #endregion

        #region Query

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductsById(int id)
        {
            var product = await _queryService.GetProductByIdAsync(id); ;
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("{minPrice}/{maxPrice}")]
        public async Task<ActionResult<List<Product>>> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var products = await _queryService.GetProductsByPriceRangeAsync(minPrice, maxPrice);
            return Ok(products);
        }

        [HttpGet("{productId}/related")]
        public async Task<ActionResult<List<Product>>> GetRelatedProducts(int productId)
        {
            var products = await _queryService.GetRelatedProductsAsync(productId);
            return Ok(products);
        }

        [HttpGet("availability/{inStock}")]
        public async Task<ActionResult<List<Product>>> GetAvailableProducts(bool inStock)
        {
            var products = await _queryService.GetProductsByAvailabilityAsync(inStock);
            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _queryService.GetProductsAsync();
        }

        [HttpGet("bybrand/{brandId}")]
        public async Task<ActionResult<List<Product>>> GetProductsByBrand(int brandId)
        {
            return await _queryService.GetProductsByBrandAsync(brandId);
        }

        [HttpGet("bycategory/{categoryId}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategory(int categoryId)
        {
            List<Product> products = await _queryService.GetProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        [HttpGet("color/{color}")]
        public async Task<ActionResult<List<Product>>> GetProductsByColor(string color)
        {
            var products = await _queryService.GetProductsByColorAsync(color);
            return Ok(products);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            List<Category> categories = await _queryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("categories/{categoryId}/recommended")]
        public async Task<ActionResult<List<Product>>> GetRecommendedProducts(int categoryId)
        {
            var products = await _queryService.GetRecommendedProductsAsync(categoryId);
            return Ok(products);
        }

        [HttpGet("new")]
        public async Task<ActionResult<List<Product>>> GetNewProducts()
        {
            var products = await _queryService.GetProductsSortedByDateAsync();
            return Ok(products);
        }

        [HttpGet("size/{size}")]
        public async Task<ActionResult<List<Product>>> GetProductsBySize(string size)
        {
            var products = await _queryService.GetProductsBySizeAsync(size);
            return Ok(products);
        }

        [HttpGet("sorted/{sortOption}")]
        public async Task<ActionResult<List<Product>>> GetProductsSorted(ProductSortOption sortOption)
        {
            var products = await _queryService.GetProductsSortedAsync(sortOption);
            return Ok(products);
        }

        #endregion
    }
}
