using HRMS.Domain.Enums;

namespace HRMS.Domain.Entities;

public sealed class Profile : Entity
{
    public Guid EmployeeId { get; private set; }
    public Employee Employee { get; private set; } = null!;
    public Guid DepartmentId { get; private set; }
    public Department Department { get; private set; }= null!;
    public Position Position { get; private set; }
    public Guid? SupervisorId { get; private set; }
    public Profile?  Supervisor { get; private set; } = null!;
    private readonly List<Profile> _subordinates = new();
    public IReadOnlyCollection<Attendance> Attendances { get; private set; } = new List<Attendance>();
    public IReadOnlyCollection<Profile> Subordinates => _subordinates.AsReadOnly();
    public IReadOnlyCollection<ProjectProfiles> ProjectProfiles { get; private set; } = new List<ProjectProfiles>();
    public IReadOnlyCollection<LeaveRequest> LeaveRequests { get; private set; } = new List<LeaveRequest>();
    
}