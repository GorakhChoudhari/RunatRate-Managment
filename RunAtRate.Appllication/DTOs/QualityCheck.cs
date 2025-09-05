

namespace RunAtRate.Appllication.DTOs;

public class QualityChecks
{
    public int QCID { get; set; }
    public int BatchID { get; set; }
    public int CheckedBy { get; set; }
    public DateTime QCDate { get; set; }
    public string Result { get; set; } = string.Empty;

    // Navigation
    public ProductionBatch? Batch { get; set; }
    public Employee? Employee { get; set; }
}
