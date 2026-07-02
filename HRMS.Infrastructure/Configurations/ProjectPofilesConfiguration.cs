using HRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Infrastructure.Configurations;

public class ProjectPofilesConfiguration: IEntityTypeConfiguration<ProjectProfiles>
{
    public void Configure(EntityTypeBuilder<ProjectProfiles> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(pp=>pp.Profile)
            .WithMany(p=>p.ProjectProfiles)
            .HasForeignKey(p=>p.ProfileId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(pp=>pp.Project)
            .WithMany(p=>p.ProjectProfiles)
            .HasForeignKey(p=>p.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}