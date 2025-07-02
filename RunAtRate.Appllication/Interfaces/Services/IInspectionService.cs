
using RunAtRate.Appllication.DTOs;

namespace RunAtRate.Application.Interfaces.Services;

public interface IInspectionService
{
    Task<InspectionDto> GetInspectionByIdAsync(int id);
}

