using HRMS.Application.CQRS.Departments.Commands;
using HRMS.Application.CQRS.Departments.Queries;
using HRMS.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentResponseDto>>> GetAll(
        CancellationToken cancellationToken)
    {
        var departments = await _mediator.Send(new GetAllDepartmentsQuery(), cancellationToken);
        return Ok(departments);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        DepartmentRequestDto request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var command = new AddDepartmentCommand(
            request.Name, request.Code, request.Latitude, request.Longitude);

        var id = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetAll), new { id }, id);
    }
}