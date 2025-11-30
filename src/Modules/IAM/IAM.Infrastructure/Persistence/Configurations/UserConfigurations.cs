using IAM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IAM.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "Users", "iam");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.Property(u => u.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);
    }
}



