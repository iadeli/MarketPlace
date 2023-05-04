using Market.Domain;

namespace Market.Application.Interfaces
{
    public interface IProductQueryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsByAvailabilityAsync(bool inStock);
        Task<List<Product>> GetProductsByBrandAsync(int brandId);
        Task<List<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<List<Product>> GetProductsByColorAsync(string color);
        Task<List<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<List<Product>> GetProductsBySizeAsync(string size);
        Task<List<Product>> GetProductsSortedAsync(ProductSortOption sortOption);
        Task<List<Product>> GetProductsSortedByDateAsync();
        Task<List<Product>> GetRecommendedProductsAsync(int categoryId);
        Task<List<Product>> GetRelatedProductsAsync(int productId);
    }
}