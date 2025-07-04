

using RunAtRate.Appllication.DTOs;

namespace RunAtRate.Appllication.Interfaces.Repositories;

public  interface IInspectionRepostory
{
    Task<InspectionDto> GetInspectionByIdAsync(int id);
}
