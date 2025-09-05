

using RunAtRate.Appllication.DTOs;

namespace RunAtRate.Appllication.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> GetEmpByIdAsync(int id);
}
