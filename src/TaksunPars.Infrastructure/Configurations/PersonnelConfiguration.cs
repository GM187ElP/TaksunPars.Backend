using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaksunPars.Core.Entities;

namespace TaksunPars.Infrastructure.Configurations;

public class PersonnelConfiguration : IEntityTypeConfiguration<Personnel>
{
    public void Configure(EntityTypeBuilder<Personnel> builder)
    {
        builder.ToTable("Personnel");

        builder.HasKey(p => p.Id);
        builder.Property(d => d.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.PersonnelCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.NationalId)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.MobileNumber)
            .HasMaxLength(20);

        builder.Property(p => p.AccountingNumber)
            .HasMaxLength(50);

        // One-to-Many relationship with PaySlips
        builder.HasMany(p => p.PaySlips)
            .WithOne(ps => ps.Personnel)
            .HasForeignKey(ps => ps.PersonnelId)
            .OnDelete(DeleteBehavior.Cascade);

        // Unique indexes
        builder.HasIndex(p => p.PersonnelCode)
            .IsUnique();

        builder.HasIndex(p => p.NationalId)
            .IsUnique();
    }
}