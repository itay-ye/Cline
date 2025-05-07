namespace InventoryApi.Services;

using InventoryApi.Models;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold);
    Task<Product> CreateProductAsync(Product product);
    Task<Product?> UpdateProductAsync(int id, Product product);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> UpdateStockQuantityAsync(int id, int quantity);
}
