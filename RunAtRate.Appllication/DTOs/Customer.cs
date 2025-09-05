

namespace RunAtRate.Appllication.DTOs;

public class Customer
{
    public int CustomerID { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public int CountryID { get; set; }

    // Navigation
    public Country? Country { get; set; }
    public ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
