using MediatR;

namespace HRMS.Application.CQRS.Departments.Commands;

public class DeleteDepartmentCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public DeleteDepartmentCommand(Guid id)
    {
        Id = id;
    }
    
}