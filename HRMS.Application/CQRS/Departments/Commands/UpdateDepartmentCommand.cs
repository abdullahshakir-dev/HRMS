using HRMS.Application.DTOs;
using HRMS.Domain.Entities;
using MediatR;

namespace HRMS.Application.CQRS.Departments.Commands;

public class UpdateDepartmentCommand : IRequest<DepartmentRequestDto>
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    public double Latitude  { get; private set; }
    public double Longitude { get; private set; }
    
    public UpdateDepartmentCommand(Guid id, string name, string code, double latitude,  double longitude)
    {
        Id = id;
        Name = name;
        Code = code;
        Latitude = latitude;
        Longitude = longitude;
    }
}