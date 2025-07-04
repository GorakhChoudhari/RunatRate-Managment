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
    /// <summary>
    /// Retrieves a specific inspection record by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the inspection.</param>
    /// <returns>
    /// Returns <see cref="InspectionDto"/> with HTTP 200 OK if found,
    /// or HTTP 204 NoContent if no matching record exists.
    /// </returns>
    /// <response code="200">Inspection found and returned successfully.</response>
    /// <response code="204">No inspection found with the specified ID.</response>

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

