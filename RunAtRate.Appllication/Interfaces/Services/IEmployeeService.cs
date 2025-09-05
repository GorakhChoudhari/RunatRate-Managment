

using RunAtRate.Appllication.DTOs;

namespace RunAtRate.Appllication.Interfaces.Services
{
    public  interface IEmployeeService
    {
        Task<Employee> GetEmpByIdAsync(int id);
    }
}
