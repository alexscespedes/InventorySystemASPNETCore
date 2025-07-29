using System;

namespace InventorySystem.Domain;

public enum TransactionType
{
    In,
    Out
}

public class StockTransaction
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }

    public TransactionType Type { get; set; }

    public int Quanity { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

}
