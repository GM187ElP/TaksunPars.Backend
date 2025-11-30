using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class ProvinceConfigurations : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "Provinces", "hr");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasMany(x => x.Cities)
            .WithOne(x => x.Province)
            .HasForeignKey(x => x.ProvinceId);

        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}
