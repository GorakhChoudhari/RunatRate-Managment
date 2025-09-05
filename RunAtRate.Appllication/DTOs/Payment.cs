
namespace RunAtRate.Appllication.DTOs;

public class Payment
{
    public int PaymentID { get; set; }                  // PK
    public int OrderID { get; set; }                    // FK -> Orders
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string PaymentMethod { get; set; } = string.Empty; // Cash/Card/UPI/NetBanking

    // Navigation
    public Orders? Order { get; set; }
}
