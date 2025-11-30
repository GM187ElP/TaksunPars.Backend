using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payslips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeCode = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false),
                    Month = table.Column<string>(type: "text", nullable: false),
                    DailySalary = table.Column<long>(type: "bigint", nullable: true),
                    WorkingDays = table.Column<int>(type: "integer", nullable: true),
                    MonthlyBaseSalary = table.Column<long>(type: "bigint", nullable: true),
                    WorkerBenefit = table.Column<long>(type: "bigint", nullable: true),
                    HousingAllowance = table.Column<long>(type: "bigint", nullable: true),
                    ChildAllowance = table.Column<long>(type: "bigint", nullable: true),
                    FamilyOrFuelAllowance = table.Column<long>(type: "bigint", nullable: true),
                    LunchAllowance = table.Column<long>(type: "bigint", nullable: true),
                    MissionAllowance = table.Column<long>(type: "bigint", nullable: true),
                    MobileAllowance = table.Column<long>(type: "bigint", nullable: true),
                    CommissionOvertime = table.Column<long>(type: "bigint", nullable: true),
                    ResponsibilityAllowance = table.Column<long>(type: "bigint", nullable: true),
                    OtherBenefits = table.Column<long>(type: "bigint", nullable: true),
                    TotalSalaryAndBenefits = table.Column<long>(type: "bigint", nullable: true),
                    InsuranceWorkerShare = table.Column<long>(type: "bigint", nullable: true),
                    SupplementaryInsurance = table.Column<long>(type: "bigint", nullable: true),
                    SalaryTax = table.Column<long>(type: "bigint", nullable: true),
                    OnePerThousandInsurance = table.Column<long>(type: "bigint", nullable: true),
                    FundLoanDeducted = table.Column<long>(type: "bigint", nullable: true),
                    FundLoanRemaining = table.Column<long>(type: "bigint", nullable: true),
                    CompanyLoanDeducted = table.Column<long>(type: "bigint", nullable: true),
                    CompanyLoanRemaining = table.Column<long>(type: "bigint", nullable: true),
                    DebtToCompany = table.Column<long>(type: "bigint", nullable: true),
                    PaidLeaveInDays = table.Column<int>(type: "integer", nullable: true),
                    UnpaidLeaveInDays = table.Column<int>(type: "integer", nullable: true),
                    CommissionReserve = table.Column<long>(type: "bigint", nullable: true),
                    TotalDeductions = table.Column<long>(type: "bigint", nullable: true),
                    GrossReceivable = table.Column<long>(type: "bigint", nullable: true),
                    InsuranceAndTaxDeductions = table.Column<long>(type: "bigint", nullable: true),
                    NetReceivable = table.Column<long>(type: "bigint", nullable: true),
                    CompanyDeductions = table.Column<long>(type: "bigint", nullable: true),
                    NetPayable = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payslips");
        }
    }
}
