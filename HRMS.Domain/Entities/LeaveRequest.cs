using HRMS.Domain.Enums;

namespace HRMS.Domain.Entities;

public sealed class LeaveRequest : Entity
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Guid ProfileId { get; private set; }
    public Guid ApprovedById { get; private set; }
    public LeaveRequestStatus Status { get; private set; }

    public Profile Profile { get; private set; } = null!;

    public LeaveRequest(DateTime startDate, DateTime endDate, Guid profileId, Guid approvedById)
    {
        if (startDate.Date < DateTime.UtcNow.Date)                                                                                                                                
            throw new ArgumentException("Leave cannot start in the past.");                                                                                                       
        if (endDate < startDate)                                                                                                                                                  
            throw new ArgumentException("End date must be on or after start date.");  
        
        StartDate = startDate;
        EndDate = endDate;
        Status = LeaveRequestStatus.Pending;
        ProfileId = profileId;
    }
    
    private  LeaveRequest()
    {
    }
}