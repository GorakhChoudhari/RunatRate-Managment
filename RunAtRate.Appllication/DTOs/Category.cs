

namespace RunAtRate.Appllication.DTOs;

public class Category
{
    public int CategoryID { get; set; }                 // PK
    public string CategoryName { get; set; } = string.Empty;

    // Navigation
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
