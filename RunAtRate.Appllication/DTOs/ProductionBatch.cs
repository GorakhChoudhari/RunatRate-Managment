

namespace RunAtRate.Appllication.DTOs;

public class ProductionBatch
{
    public int BatchID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    // Navigation property
    public ICollection<QualityChecks> QualityChecks { get; set; } = new List<QualityChecks>();
}
