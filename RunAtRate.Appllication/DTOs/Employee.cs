

namespace RunAtRate.Appllication.DTOs;

public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public DateTime HireDate { get; set; }

    public int? ManagerID { get; set; } // self-FK

    // Navigation
    public Employee? Manager { get; set; }
    //public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
    //public ICollection<QualityChecks> QualityChecks { get; set; } = new List<QualityChecks>();

}
