using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaksunPars.Core.Entities;

namespace TaksunPars.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(d => d.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);

        // One-to-One relationship with Personnel
        builder.HasOne(u => u.Personnel)
            .WithOne(p => p.User)
            .HasForeignKey<User>(u => u.PersonnelId)
            .OnDelete(DeleteBehavior.Cascade);

        // Unique index on Username
        builder.HasIndex(u => u.Username)
            .IsUnique();
    }
}