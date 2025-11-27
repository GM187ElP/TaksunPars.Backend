using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class JobTitleConfig : IEntityTypeConfiguration<JobTitle>
{
    public void Configure(EntityTypeBuilder<JobTitle> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "JobTitles");
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");
        builder.HasIndex(j => j.Title).IsUnique();
        builder.Property(j => j.Title).HasMaxLength(35);

        builder.HasOne(j => j.Department)
               .WithMany(d => d.JobTitles)
               .HasPrincipalKey(j => j.Name)
               .HasForeignKey(j => j.DepartmentId).OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(j => j.Employees)
               .WithOne(emp => emp.JobTitle)
               .HasPrincipalKey(j => j.Title)
               .HasForeignKey(emp => emp.DepartmentId);
    }
}

