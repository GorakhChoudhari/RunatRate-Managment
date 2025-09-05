

using System.Diagnostics.Metrics;

namespace RunAtRate.Appllication.DTOs;

public class Supplier
{
    public int SupplierID { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public int CountryID { get; set; }

    // Navigation
    public Country? Country { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
