using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.Domain.Entities;
using Shared.Interfaces;

namespace Payroll.Infrastructure.Persistence.Configurations;

public class PayslipConfigurations : IEntityTypeConfiguration<Payslip>
{
    public void Configure(EntityTypeBuilder<Payslip> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.EmployeeCode)
            .IsRequired()
            .HasMaxLength(21);

        builder.HasIndex(p => p.EmployeeCode)
           .IsUnique();

        builder.Property(p => p.Year)
            .IsRequired()
            .HasMaxLength(4);

        builder.Property(p => p.Month)
            .IsRequired()
            .HasMaxLength(2);
    }
}


