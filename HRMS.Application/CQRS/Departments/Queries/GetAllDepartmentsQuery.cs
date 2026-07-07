using HRMS.Application.DTOs;
using MediatR;

namespace HRMS.Application.CQRS.Departments.Queries;

public class GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmentResponseDto>>
{
    
}