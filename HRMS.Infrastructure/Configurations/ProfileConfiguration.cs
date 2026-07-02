using HRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Infrastructure.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasKey(p=>p.Id);
        builder.HasOne(p=>p.Department)
            .WithMany(d=>d.Profiles)
            .HasForeignKey(d=>d.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(p=>p.Supervisor)
            .WithMany(p=>p.Subordinates)
            .HasForeignKey(d=>d.SupervisorId)
            .OnDelete(DeleteBehavior.Restrict);
        
       builder.HasMany(p=>p.Attendances)
           .WithOne(p=>p.Profile)
           .HasForeignKey(f=>f.ProfileId)
           .OnDelete(DeleteBehavior.Restrict);
       
       builder.HasMany(p=>p.LeaveRequests)
           .WithOne(p=>p.Profile)
           .HasForeignKey(f=>f.ProfileId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}