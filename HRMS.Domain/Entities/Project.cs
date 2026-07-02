namespace HRMS.Domain.Entities;

public sealed class Project : Entity
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    
    public IReadOnlyCollection<ProjectProfiles> ProjectProfiles { get; private set; } = new List<ProjectProfiles>();

    public Project(string name, string code)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentException("Project name cannot be empty");
        
        Name = name;
        Code = code;
    }
    
    private  Project()
    {
        Name = string.Empty;
        Code = string.Empty;
    }
}