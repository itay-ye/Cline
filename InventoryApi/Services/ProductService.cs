namespace InventoryApi.Services;

using Microsoft.EntityFrameworkCore;
using InventoryApi.Data;
using InventoryApi.Models;

public class ProductService : IProductService
{
    private readonly InventoryContext _context;

    public ProductService(InventoryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold)
    {
        return await _context.Products
            .Where(p => p.StockQuantity < threshold && !p.IsDiscontinued)
            .OrderBy(p => p.StockQuantity)
            .ToListAsync();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateProductAsync(int id, Product product)
    {
        var existingProduct = await _context.Products.FindAsync(id);
        if (existingProduct == null)
        {
            return null;
        }

        decimal priceRatio = existingProduct.Price > 0 ? product.Price / existingProduct.Price : 1;
        if (priceRatio != 1)
        {
            existingProduct.StockQuantity = (int)(existingProduct.StockQuantity * (1 / priceRatio));
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Category = product.Category;
        existingProduct.IsDiscontinued = product.IsDiscontinued;

        await _context.SaveChangesAsync();
        return existingProduct;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateStockQuantityAsync(int id, int quantity)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        product.StockQuantity = quantity;
        product.LastRestocked = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
}
