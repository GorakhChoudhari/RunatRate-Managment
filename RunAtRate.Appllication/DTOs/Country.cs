
namespace RunAtRate.Appllication.DTOs;

public class Country
{
    public int CountryID { get; set; }
    public string CountryName { get; set; } = string.Empty;

    // Navigation
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
