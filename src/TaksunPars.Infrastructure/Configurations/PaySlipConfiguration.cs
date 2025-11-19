using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaksunPars.Core.Entities;

namespace TaksunPars.Infrastructure.Configurations;

public class PaySlipConfiguration : IEntityTypeConfiguration<Payslip>
{
    public void Configure(EntityTypeBuilder<Payslip> builder)
    {
        builder.ToTable("Payslips");

        builder.HasKey(ps => ps.Id);
        builder.Property(d => d.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        // Required string fields
        builder.Property(ps => ps.PersonnelCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(ps => ps.Year)
            .IsRequired()
            .HasMaxLength(4);

        builder.Property(ps => ps.Month)
            .IsRequired()
            .HasMaxLength(2);

        // All long/numeric fields for salary and benefits
        builder.Property(ps => ps.DailySalary).IsRequired();
        builder.Property(ps => ps.WorkingDays).IsRequired();
        builder.Property(ps => ps.MonthlyBaseSalary).IsRequired();
        builder.Property(ps => ps.WorkerBenefit).IsRequired();
        builder.Property(ps => ps.HousingAllowance).IsRequired();
        builder.Property(ps => ps.ChildAllowance).IsRequired();
        builder.Property(ps => ps.FamilyOrFuelAllowance).IsRequired();
        builder.Property(ps => ps.LunchAllowance).IsRequired();
        builder.Property(ps => ps.MissionAllowance).IsRequired();
        builder.Property(ps => ps.MobileAllowance).IsRequired();
        builder.Property(ps => ps.CommissionOvertime).IsRequired();
        builder.Property(ps => ps.ResponsibilityAllowance).IsRequired();
        builder.Property(ps => ps.OtherBenefits).IsRequired();
        builder.Property(ps => ps.TotalSalaryAndBenefits).IsRequired();

        // Deductions
        builder.Property(ps => ps.InsuranceWorkerShare).IsRequired();
        builder.Property(ps => ps.SupplementaryInsurance).IsRequired();
        builder.Property(ps => ps.SalaryTax).IsRequired();
        builder.Property(ps => ps.OnePerThousandInsurance).IsRequired();

        // Loans
        builder.Property(ps => ps.FundLoanDeducted).IsRequired();
        builder.Property(ps => ps.FundLoanRemaining).IsRequired();
        builder.Property(ps => ps.CompanyLoanDeducted).IsRequired();
        builder.Property(ps => ps.CompanyLoanRemaining).IsRequired();

        // Debt and Leave
        builder.Property(ps => ps.DebtToCompany).IsRequired();
        builder.Property(ps => ps.PaidLeaveInDays).IsRequired();
        builder.Property(ps => ps.UnpaidLeaveInDays).IsRequired();

        // Totals
        builder.Property(ps => ps.CommissionReserve).IsRequired();
        builder.Property(ps => ps.TotalDeductions).IsRequired();
        builder.Property(ps => ps.GrossReceivable).IsRequired();
        builder.Property(ps => ps.InsuranceAndTaxDeductions).IsRequired();
        builder.Property(ps => ps.NetReceivable).IsRequired();
        builder.Property(ps => ps.CompanyDeductions).IsRequired();
        builder.Property(ps => ps.NetPayable).IsRequired();

        // Composite unique index on PersonnelCode + Year + Month
        builder.HasIndex(ps => new { ps.PersonnelCode, ps.Year, ps.Month })
            .IsUnique();
    }
}