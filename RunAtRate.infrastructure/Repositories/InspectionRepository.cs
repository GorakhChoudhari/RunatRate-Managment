
using RunAtRate.Appllication.DTOs;
using RunAtRate.Appllication.Interfaces.Repositories;
using RunAtRate.Core.Interfaces;

namespace RunAtRate.infrastructure.Repositories;
public class InspectionRepository(IGenericRepository<InspectionDto> _genericRepo) : IInspectionRepostory
{
    public async Task<InspectionDto> GetInspectionByIdAsync(int id)
    {
        var entity = await _genericRepo.GetNestedIncludeAsync(
            predicate: x => x.Id == id,
            include: query => query // ⬅️ Optional Includes go here if needed
        );

        return entity == null ? null : new InspectionDto
        {
            Id = entity.Id,
            PartName = entity.PartName,
            ScheduledDate = entity.ScheduledDate,
            Status = entity.Status
        };
    }
}




