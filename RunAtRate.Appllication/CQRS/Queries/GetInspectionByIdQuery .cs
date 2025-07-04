using MediatR;
using RunAtRate.Appllication.DTOs;

namespace RunAtRate.Application.CQRS.Inspections.Queries;

public class GetInspectionByIdQuery : IRequest<InspectionDto>
{
    public int Id { get; set; }
}


