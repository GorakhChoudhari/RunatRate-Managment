using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RunAtRate.Application.CQRS.Inspections.Queries;
using RunAtRate.Appllication.DTOs;
using Serilog.Core;
using System.Net;

namespace RunAtRate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InspectionController(ILogger<InspectionController> logger, IMediator _mediator) : ControllerBase
{
   

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(InspectionDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetInspectionById(int id)
    {
        logger.LogInformation("Start: GetInspectionById");
        var result = await _mediator.Send(new GetInspectionByIdQuery { Id = id });
        logger.LogInformation("End: GetInspectionById");
        return result == null ? NoContent() : Ok(result);
    }

}

