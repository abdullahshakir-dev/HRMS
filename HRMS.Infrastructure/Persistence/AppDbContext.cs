using HRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Persistence;

public class AppDbContext (DbContextOptions options) : DbContext(options)
{
    DbSet<Profile> Profiles { get; set; }
    DbSet<Employee> Employees { get; set; }
    DbSet<LeaveRequest> LeaveRequests { get; set; }
    DbSet<Attendance> Attendances { get; set; }
    DbSet<Department> Departments { get; set; }
    DbSet<Project> Projects { get; set; }
    DbSet<ProjectProfiles> ProjectProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
    }
}