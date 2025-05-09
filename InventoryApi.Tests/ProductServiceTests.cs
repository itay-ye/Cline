using InventoryApi.Data;
using InventoryApi.Models;
using InventoryApi.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InventoryApi.Tests;

public class ProductServiceTests
{
    private InventoryContext GetTestContext()
    {
        var options = new DbContextOptionsBuilder<InventoryContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new InventoryContext(options);
        return context;
    }

    [Fact]
    public async Task CreateProduct_ShouldAddNewProduct()
    {
        // Arrange
        var context = GetTestContext();
        var service = new ProductService(context);
        var product = new Product
        {
            Name = "Test Product",
            Price = 19.99m,
            StockQuantity = 10,
            Category = "Test Category"
        };

        // Act
        var result = await service.CreateProductAsync(product);

        // Assert
        Assert.NotEqual(0, result.Id);
        Assert.Equal("Test Product", result.Name);
        Assert.Equal(19.99m, result.Price);
        Assert.Equal(10, result.StockQuantity);
    }

    [Fact]
    public async Task GetLowStockProducts_ShouldReturnProductsBelowThreshold()
    {
        // Arrange
        var context = GetTestContext();
        var service = new ProductService(context);

        await context.Products.AddRangeAsync(new[]
        {
            new Product { Name = "Low Stock", StockQuantity = 2 },
            new Product { Name = "Medium Stock", StockQuantity = 5 },
            new Product { Name = "High Stock", StockQuantity = 10 }
        });
        await context.SaveChangesAsync();

        // Act
        var result = await service.GetLowStockProductsAsync(3);

        // Assert
        Assert.Single(result);
        Assert.Equal("Low Stock", result.First().Name);
    }

    [Fact]
    public async Task GetLowStockProducts_ShouldIncludeProductsExactlyAtThreshold()
    {
        // Arrange
        var context = GetTestContext();
        var service = new ProductService(context);
        var threshold = 5;

        await context.Products.AddRangeAsync(new[]
        {
            new Product { Name = "Below Threshold", StockQuantity = 2 },
            new Product { Name = "At Threshold", StockQuantity = threshold },
            new Product { Name = "Above Threshold", StockQuantity = 10 }
        });
        await context.SaveChangesAsync();

        // Act
        var result = await service.GetLowStockProductsAsync(threshold);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(result, p => p.Name == "At Threshold");
    }

    [Fact]
    public async Task UpdateStockQuantity_ShouldUpdateLastRestockedDate()
    {
        // Arrange
        var context = GetTestContext();
        var service = new ProductService(context);
        var initialDate = DateTime.UtcNow.AddDays(-1);

        var product = new Product
        {
            Name = "Test Product",
            Price = 10.00m,
            StockQuantity = 5,
            LastRestocked = initialDate
        };
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        // Act
        await service.UpdateStockQuantityAsync(product.Id, 10);
        var updatedProduct = await context.Products.FindAsync(product.Id);

        // Assert
        Assert.NotNull(updatedProduct);
        Assert.Equal(10, updatedProduct.StockQuantity);
        Assert.True(updatedProduct.LastRestocked > initialDate);
    }
}
