using MediatR;
using Microsoft.AspNetCore.Mvc;
using RunAtRate.Application.CQRS.Inspections.Queries;
using RunAtRate.Appllication.DTOs;

namespace RunAtRate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InspectionController : ControllerBase
{
    private readonly IMediator _mediator;

    public InspectionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InspectionDto>> GetById(int id)
    {
        var result = await _mediator.Send(new GetInspectionByIdQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }
}

