using IAM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IAM.Infrastructure.Persistence.Configurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(210);

        builder.Property(r => r.NormalizedName)
            .HasMaxLength(210);

        builder.HasIndex(r => r.NormalizedName)
            .IsUnique();

        builder.Property(r => r.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId);
    }
}

