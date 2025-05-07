namespace InventoryApi.Data;

using Microsoft.EntityFrameworkCore;
using InventoryApi.Models;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        // Seed some initial data
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Widget A",
                Price = 19.99M,
                StockQuantity = 50,
                Category = "Widgets",
                LastRestocked = DateTime.UtcNow,
                IsDiscontinued = false
            },
            new Product
            {
                Id = 2,
                Name = "Gadget B",
                Price = 29.99M,
                StockQuantity = 3,
                Category = "Gadgets",
                LastRestocked = DateTime.UtcNow.AddDays(-30),
                IsDiscontinued = false
            },
            new Product
            {
                Id = 3,
                Name = "Legacy Item",
                Price = 9.99M,
                StockQuantity = 0,
                Category = "Discontinued",
                LastRestocked = DateTime.UtcNow.AddYears(-1),
                IsDiscontinued = true
            }
        );
    }
}
