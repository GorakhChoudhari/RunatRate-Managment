

using MediatR;
using RunAtRate.Appllication.DTOs;

namespace RunAtRate.Appllication.CQRS.Queries;

public class GetEmployeeByIdQuery : IRequest<Employee>
{
    public int Id { get; set; }
}
