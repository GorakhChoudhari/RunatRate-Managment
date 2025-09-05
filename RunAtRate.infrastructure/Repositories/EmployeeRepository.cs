using Microsoft.EntityFrameworkCore;
using RunAtRate.Appllication.DTOs;
using RunAtRate.Appllication.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunAtRate.infrastructure.Repositories;

public class EmployeeRepository(AppDbContext _context) : IEmployeeRepository
{
    
    public async Task<Employee> GetEmpByIdAsync(int id)
    {
        return await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmployeeID == id);
    }
}
