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
    public async Task<IActionResult> GetAll(
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

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(
        Guid id, [FromBody] DepartmentRequestDto request, CancellationToken cancellationToken)
    {
        var updated = await _mediator.Send(
            new UpdateDepartmentCommand(
                id, request.Name, request.Code, request.Latitude, request.Longitude),
            cancellationToken);

        if (updated is null) return NotFound("Department with this ID not found");

        return Ok(updated);
    }


    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isDeleted = await _mediator.Send(new DeleteDepartmentCommand(id));

        if (isDeleted is false) return  NotFound("Department with this ID not found");

        return NoContent();
    }
}