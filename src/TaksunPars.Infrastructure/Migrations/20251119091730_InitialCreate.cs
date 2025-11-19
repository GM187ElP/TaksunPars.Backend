using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaksunPars.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonnelCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NationalId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    AccountingNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnel_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payslips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonnelCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PersonnelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Month = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    DailySalary = table.Column<long>(type: "bigint", nullable: false),
                    WorkingDays = table.Column<int>(type: "integer", nullable: false),
                    MonthlyBaseSalary = table.Column<long>(type: "bigint", nullable: false),
                    WorkerBenefit = table.Column<long>(type: "bigint", nullable: false),
                    HousingAllowance = table.Column<long>(type: "bigint", nullable: false),
                    ChildAllowance = table.Column<long>(type: "bigint", nullable: false),
                    FamilyOrFuelAllowance = table.Column<long>(type: "bigint", nullable: false),
                    LunchAllowance = table.Column<long>(type: "bigint", nullable: false),
                    MissionAllowance = table.Column<long>(type: "bigint", nullable: false),
                    MobileAllowance = table.Column<long>(type: "bigint", nullable: false),
                    CommissionOvertime = table.Column<long>(type: "bigint", nullable: false),
                    ResponsibilityAllowance = table.Column<long>(type: "bigint", nullable: false),
                    OtherBenefits = table.Column<long>(type: "bigint", nullable: false),
                    TotalSalaryAndBenefits = table.Column<long>(type: "bigint", nullable: false),
                    InsuranceWorkerShare = table.Column<long>(type: "bigint", nullable: false),
                    SupplementaryInsurance = table.Column<long>(type: "bigint", nullable: false),
                    SalaryTax = table.Column<long>(type: "bigint", nullable: false),
                    OnePerThousandInsurance = table.Column<long>(type: "bigint", nullable: false),
                    FundLoanDeducted = table.Column<long>(type: "bigint", nullable: false),
                    FundLoanRemaining = table.Column<long>(type: "bigint", nullable: false),
                    CompanyLoanDeducted = table.Column<long>(type: "bigint", nullable: false),
                    CompanyLoanRemaining = table.Column<long>(type: "bigint", nullable: false),
                    DebtToCompany = table.Column<long>(type: "bigint", nullable: false),
                    PaidLeaveInDays = table.Column<int>(type: "integer", nullable: false),
                    UnpaidLeaveInDays = table.Column<int>(type: "integer", nullable: false),
                    CommissionReserve = table.Column<long>(type: "bigint", nullable: false),
                    TotalDeductions = table.Column<long>(type: "bigint", nullable: false),
                    GrossReceivable = table.Column<long>(type: "bigint", nullable: false),
                    InsuranceAndTaxDeductions = table.Column<long>(type: "bigint", nullable: false),
                    NetReceivable = table.Column<long>(type: "bigint", nullable: false),
                    CompanyDeductions = table.Column<long>(type: "bigint", nullable: false),
                    NetPayable = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payslips_Personnel_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PersonnelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Personnel_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentId",
                table: "Departments",
                column: "DepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_PersonnelCode_Year_Month",
                table: "Payslips",
                columns: new[] { "PersonnelCode", "Year", "Month" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_PersonnelId",
                table: "Payslips",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_DepartmentId",
                table: "Personnel",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_NationalId",
                table: "Personnel",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_PersonnelCode",
                table: "Personnel",
                column: "PersonnelCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonnelId",
                table: "Users",
                column: "PersonnelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payslips");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Personnel");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
