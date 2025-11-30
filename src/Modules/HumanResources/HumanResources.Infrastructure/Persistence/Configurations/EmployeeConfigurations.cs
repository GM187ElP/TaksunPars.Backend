using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "Employees","hr");

        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasIndex(e => e.EmployeeCode)
            .IsUnique();

        builder.HasIndex(e => e.NationalId)
            .IsUnique();

        builder.Property(e => e.NationalId)
            .IsRequired();

        builder.Property(e => e.FirstName)
            .IsRequired();

        builder.Property(e => e.LastName)
            .IsRequired();

        builder.HasOne(e => e.SuperVisor)
            .WithMany(e => e.Employees)
            .HasForeignKey(e => e.SupervisorId);

        builder.HasMany(e => e.ChequePromissionaryNotes)
            .WithOne(c => c.Employee)
            .HasForeignKey(c => c.EmployeeId);

        builder.HasMany(e => e.TrackJobTitleAndLeaveHistories)
            .WithOne(s => s.Employee)
            .HasForeignKey(s => s.EmployeeId);

        builder.HasMany(e => e.BankAccounts)
            .WithOne(b => b.Employee)
            .HasForeignKey(b => b.EmployeeId);

        #region Conversions
        //builder.Property(e => e.GenderDisplay).HasConversion(e => Conversions.GenderType2String(e), e => Conversions.String2GenderType(e));
        //builder.Property(e => e.WorkingStatusDisplay).HasConversion(e => Conversions.WorkingStatus2String(e), e => Conversions.String2WorkingStatus(e));

        //    builder.Property(e => e.BirthDate).HasConversion(e => _Conversions.Gregorian2Farsi(e, dateDelimiter),
        //e => string.IsNullOrEmpty(e) ? throw new Exception("Invalid BirthDate") : _Conversions.Farsi2Gregorian(e, dateDelimiter));

        //    builder.Property(e => e.StartingDate).HasConversion(e => _Conversions.Gregorian2Farsi(e, dateDelimiter),
        //        e => string.IsNullOrEmpty(e) ? throw new Exception("Invalid StartingDate") : _Conversions.Farsi2Gregorian(e, dateDelimiter));

        //    builder.Property(e => e.LeavingDate).HasConversion(e => e.HasValue ? _Conversions.Gregorian2Farsi(e.Value, dateDelimiter) : null,
        //        e => string.IsNullOrEmpty(e) ? null : _Conversions.Farsi2Gregorian(e, dateDelimiter));
        #endregion
    }
}
















