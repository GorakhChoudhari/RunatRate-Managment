
namespace RunAtRate.Appllication.DTOs;

public class OrderDetail
{
    public int OrderDetailID { get; set; }              // PK
    public int OrderID { get; set; }                    // FK -> Orders
    public int ProductID { get; set; }                  // FK -> Products
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    // Navigation
    public Orders? Order { get; set; }
    public Product? Product { get; set; }
}
