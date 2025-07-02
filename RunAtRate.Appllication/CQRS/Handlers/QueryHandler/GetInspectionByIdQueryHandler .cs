using MediatR;
using RunAtRate.Application.CQRS.Inspections.Queries;
using RunAtRate.Application.Interfaces.Services;
using RunAtRate.Appllication.DTOs;

namespace RunAtRate.Application.CQRS.Inspections.Handlers.QueryHandlers;

public class GetInspectionByIdQueryHandler : IRequestHandler<GetInspectionByIdQuery, InspectionDto>
{
    private readonly IInspectionService _inspectionService;

    public GetInspectionByIdQueryHandler(IInspectionService inspectionService)
    {
        _inspectionService = inspectionService;
    }

    public async Task<InspectionDto> Handle(GetInspectionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _inspectionService.GetInspectionByIdAsync(request.Id);
    }
}

