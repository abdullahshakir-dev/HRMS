using HRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasIndex(d => d.Id);
        builder.HasIndex(d => d.Code)
            .IsUnique();
        builder.Property(d => d.Name)
            .IsRequired().HasMaxLength(50);
        
    }
}