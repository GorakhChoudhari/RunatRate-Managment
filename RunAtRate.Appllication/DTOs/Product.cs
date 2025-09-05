

namespace RunAtRate.Appllication.DTOs;

public class Product
{
    public int ProductID { get; set; }                 // PK
    public string ProductName { get; set; } = string.Empty;
    public int CategoryID { get; set; }                // FK -> Categories
    public int SupplierID { get; set; }                // FK -> Suppliers
    public decimal Price { get; set; }
    public int Stock { get; set; }

    // Navigation
    public Category? Category { get; set; }
    public Supplier? Supplier { get; set; }
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public ICollection<ProductionBatch> ProductionBatches { get; set; } = new List<ProductionBatch>();
}
