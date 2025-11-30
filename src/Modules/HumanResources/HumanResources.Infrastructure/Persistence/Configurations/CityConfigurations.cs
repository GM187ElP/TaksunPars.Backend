using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class CityConfigurations : IEntityTypeConfiguration<City>
{
    void IEntityTypeConfiguration<City>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<City> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "Cities","hr");

        builder.HasKey(x=>x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasMany(x => x.BirthPlaces)
            .WithOne(x => x.BirthPlace)
            .HasForeignKey(x => x.BirthPlaceId);

        builder.HasMany(x => x.ShenasnameIssuedPlaces)
            .WithOne(x => x.ShenasnameIssuedPlace)
            .HasForeignKey(x => x.ShenasnameIssuedPlaceId);

        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}
