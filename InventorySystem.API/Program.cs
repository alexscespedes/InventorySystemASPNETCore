using Microsoft.EntityFrameworkCore;
using InventorySystem.Infrastructure.Data;
using InventorySystem.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

SeedDatabase(app);

app.Run();

void SeedDatabase(IHost app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();

    if (!context.Products.Any())
    {
        var product = new Product { Name = "Laptop", SKU = "LP-123", Description = "Portable Computer" };
        var warehouse = new Warehouse { Name = "Main Warehouse", Location = "New York" };

        context.Products.Add(product);
        context.Warehouses.Add(warehouse);
        context.SaveChanges();

        var stock = new StockTransaction
        {
            ProductId = product.Id,
            WarehouseId = warehouse.Id,
            Quanity = 20,
            Timestamp = DateTime.UtcNow
        };

        context.StockTransactions.Add(stock);
        context.SaveChanges();
    }
}
