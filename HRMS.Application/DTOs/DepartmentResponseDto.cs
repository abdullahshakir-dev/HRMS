using HRMS.Domain.Enums;

namespace HRMS.Application.DTOs;

public record DepartmentResponseDto(
    Guid Id,
    string Name,
    string Code,
    double Latitude,
    double Longitude,
    DateTime CreatedAt,
    IReadOnlyCollection<DepartmentProfileResponseDto> Profiles);

public record DepartmentProfileResponseDto(
    Guid Id,
    Guid EmployeeId,
    Position Position);
