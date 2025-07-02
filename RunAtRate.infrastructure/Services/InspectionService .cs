using RunAtRate.Application.Interfaces.Services;
using RunAtRate.Appllication.DTOs;


public class InspectionService : IInspectionService
{
    private readonly AppDbContext _context;

    public InspectionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<InspectionDto> GetInspectionByIdAsync(int id)
    {
        var inspection = await _context.Inspections.FindAsync(id);
        if (inspection == null) return null;

        return new InspectionDto
        {
            Id = inspection.Id,
            PartName = inspection.PartName,
            ScheduledDate = inspection.ScheduledDate,
            Status = inspection.Status
        };
    }
}

