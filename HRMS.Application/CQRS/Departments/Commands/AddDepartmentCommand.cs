using HRMS.Application.DTOs;
using MediatR;

namespace HRMS.Application.CQRS.Departments.Commands;

public class AddDepartmentCommand : IRequest<DepartmentResponseDto>
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public double Latitude  { get; private set; }
    public double Longitude { get; private set; }
    
    
    public AddDepartmentCommand(string name, string code, double latitude, double longitude)
    {
        Name = name;
        Code = code;
        Latitude = latitude;
        Longitude = longitude;
    }
}