

namespace RunAtRate.Appllication.DTOs;

public class Orders
{
    public int OrderID { get; set; }                    // PK
    public int CustomerID { get; set; }                 // FK -> Customers
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";

    // Navigation
    public Customer? Customer { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
