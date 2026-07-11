using HRMS.Domain.Enums;

namespace HRMS.Domain.Entities;

public sealed class Attendance : Entity
{
    public Guid ProfileId { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly? CheckIn { get; private set; }
    public TimeOnly? CheckOut { get; private set; }
    public AttendanceStatus Status { get; private set; }

    public Profile Profile { get; private set; } = null!;

    public Attendance(Guid profileId, DateOnly date)
    {
        ProfileId = profileId;
        Date = date;
        Status = AttendanceStatus.Absent;

    }

    private Attendance()
    {
        Status = AttendanceStatus.Absent;
    }

    public void RecordCheckIn(TimeOnly? time)
    {
        if (CheckIn is not null)
        {
            throw new InvalidOperationException("Attendance has already been checked out");
        }
        CheckIn = time;
        Status = time > new TimeOnly(8, 45) ? AttendanceStatus.Late : AttendanceStatus.Present;
    }
    
    public void RecordCheckOut(TimeOnly time)
    {
        if (CheckIn is null)
            throw new InvalidOperationException("Cannot check out before checking in.");
        CheckOut = time;
    }
}