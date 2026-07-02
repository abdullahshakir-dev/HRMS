namespace HRMS.Domain.Entities;

public sealed class ProjectProfiles : Entity
{
    public Guid ProfileId { get; private set; }
    public Guid ProjectId { get; private set; }

    public Profile Profile { get; private set; } = null!;
    public Project Project { get; private set; } = null!;
    
    public ProjectProfiles(Guid profileId, Guid projectId)
    {
        ProfileId = profileId;
        ProjectId = projectId;
    }
}