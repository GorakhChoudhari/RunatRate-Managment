

namespace RunAtRate.Appllication.DTOs;

public class Inventory
{
    public int InventoryID { get; set; }                // PK
    public int ProductID { get; set; }                  // FK -> Products
    public int WarehouseID { get; set; }                // FK -> Warehouses
    public int Quantity { get; set; }

    // Navigation
    public Product? Product { get; set; }
    public Warehouse? Warehouse { get; set; }
}
