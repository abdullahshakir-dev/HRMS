namespace HRMS.Domain.Entities;

public sealed class Department: Entity
{
    public Department(string name, string code, double latitude, double longitude)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(code) || double.IsNaN(latitude) ||
            double.IsNaN(longitude))
        {
            throw new ArgumentException("Invalid department name, code,  lat, long");
        }
        
        Name = name;
        Code = code;
        Latitude = latitude;
        Longitude = longitude;
    }

    private Department()
    {
        Name = string.Empty;
        Code = string.Empty;
        Latitude = 0;
        Longitude = 0;
    }
    
    public string Name { get; private set; }
    public string Code { get; private set; }
    public double Latitude  { get; private set; }
    public double Longitude { get; private set; }

    public IReadOnlyCollection<Profile> Profiles { get; private set; } =  new List<Profile>();
}