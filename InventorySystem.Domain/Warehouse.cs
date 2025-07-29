namespace InventorySystem.Domain;

public class Warehouse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
}
