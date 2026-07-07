using HRMS.Domain.Entities;
using MediatR;

namespace HRMS.Application.CQRS.Departments.Commands;

public class UpdateDepartmentCommand : IRequest<bool>
{
    public UpdateDepartmentCommand()
    {
        
    }
}