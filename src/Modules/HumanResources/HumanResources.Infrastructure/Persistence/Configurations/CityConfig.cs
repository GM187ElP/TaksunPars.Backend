using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class CityConfig : IEntityTypeConfiguration<City>
{
    void IEntityTypeConfiguration<City>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<City> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "Cities");
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");
        builder.Property(x => x.Name).HasMaxLength(21).IsRequired();
        builder.HasMany(x => x.BirthPlaces).WithOne(x => x.BirthPlace).HasForeignKey(x => x.BirthPlaceId);
        builder.HasMany(x => x.ShenasnameIssuedPlaces).WithOne(x => x.ShenasnameIssuedPlace).HasForeignKey(x => x.ShenasnameIssuedPlaceId).OnDelete(DeleteBehavior.Restrict);
    }
}

