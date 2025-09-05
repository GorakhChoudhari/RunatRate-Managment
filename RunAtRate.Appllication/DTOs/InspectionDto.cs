

namespace RunAtRate.Appllication.DTOs;

public class InspectionDto
{
    public int? Id { get; set; }
    public string? PartName { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string? Status { get; set; }
}
