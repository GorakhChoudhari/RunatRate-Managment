using MediatR;
using RunAtRate.Appllication.CQRS.Queries;
using RunAtRate.Appllication.DTOs;
using RunAtRate.Appllication.Interfaces.Services;

namespace RunAtRate.Appllication.CQRS.Handlers.QueryHandler; 

public class GetEmployeeByIdQueryHandler(IEmployeeService _employeeService) : IRequestHandler<GetEmployeeByIdQuery, Employee>
{
    public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _employeeService.GetEmpByIdAsync(request.Id);
    }
}
