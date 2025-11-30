using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "Departments", "hr");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasMany(x => x.JobTitles)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId);

        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}
