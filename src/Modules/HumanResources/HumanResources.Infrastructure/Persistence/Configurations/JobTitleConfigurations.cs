using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class JobTitleConfigurations : IEntityTypeConfiguration<JobTitle>
{
    public void Configure(EntityTypeBuilder<JobTitle> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "JobTitles","hr");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasMany(j => j.Employees)
               .WithOne(emp => emp.JobTitle)
               .HasForeignKey(emp => emp.JobTitleId);

        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}

