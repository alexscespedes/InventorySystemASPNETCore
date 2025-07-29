using System;
using InventorySystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<StockTransaction> StockTransactions => Set<StockTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Warehouse>().ToTable("Warehouses");
        modelBuilder.Entity<StockTransaction>().ToTable("StockTransactions");

        modelBuilder.Entity<StockTransaction>()
            .HasOne(st => st.Product)
            .WithMany(p => p.StockTransactions)
            .HasForeignKey(st => st.ProductId);

        modelBuilder.Entity<StockTransaction>()
            .HasOne(st => st.Warehouse)
            .WithMany(w => w.StockTransactions)
            .HasForeignKey(st => st.WarehouseId);
    }
}
