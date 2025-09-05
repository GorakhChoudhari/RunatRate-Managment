

using RunAtRate.Appllication.DTOs;
using RunAtRate.Appllication.Interfaces.Repositories;
using RunAtRate.Appllication.Interfaces.Services;

namespace RunAtRate.infrastructure.Services;

public class EmployeeService(IEmployeeRepository _employeeRepository): IEmployeeService
{
    public Task<Employee> GetEmpByIdAsync(int id)
    {
        return _employeeRepository.GetEmpByIdAsync(id);
    }
}
