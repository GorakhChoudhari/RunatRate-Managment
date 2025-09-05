
using RunAtRate.Appllication.CQRS.Queries;
using RunAtRate.Appllication.Interfaces;

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
    logger.LogInformation(LoggerConstants.LogStart, nameof(InspectionController), nameof(GetInspectionById));

    var result = await _mediator.Send(new GetInspectionByIdQuery { Id = id });

    logger.LogInformation(LoggerConstants.LogEnd, nameof(InspectionController), nameof(GetInspectionById));

    return result is null ? NoContent() : Ok(result);
    }
    [HttpGet("test-error")]
    public IActionResult TestError()
    {
        throw new Exception("Test exception for global handler");
    }
    [HttpGet]
    [Route("GetEmployeeById")]
    [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetEmpById(int Empid)
    {
        logger.LogInformation(LoggerConstants.LogStart, nameof(InspectionController), nameof(GetEmpById));

        var result = await _mediator.Send(new GetEmployeeByIdQuery { Id = Empid });

        logger.LogInformation(LoggerConstants.LogEnd, nameof(InspectionController), nameof(GetEmpById));

        return result is null ? NoContent() : Ok(result);
    }

}
