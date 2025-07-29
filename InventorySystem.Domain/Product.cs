using System;

namespace InventorySystem.Domain;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

}
