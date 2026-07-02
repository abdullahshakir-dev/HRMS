using HRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasIndex(e => e.Id);
        builder.HasIndex(e => e.Email)
            .IsUnique();
        builder.HasOne(e=>e.Profile)
            .WithOne(e => e.Employee)
            .HasForeignKey<Profile>(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}