using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hr");

            migrationBuilder.CreateTable(
                name: "BankNameList",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankNameList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTitles_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "hr",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCapital = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "hr",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    EmployeeCode = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    NationalId = table.Column<string>(type: "text", nullable: false),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    GenderDisplay = table.Column<int>(type: "integer", nullable: true),
                    WorkingStatusDisplay = table.Column<int>(type: "integer", nullable: true),
                    FatherName = table.Column<string>(type: "text", nullable: true),
                    MaritalStatusDisplay = table.Column<int>(type: "integer", nullable: true),
                    ChildrenCount = table.Column<int>(type: "integer", nullable: true),
                    ShenasnameNumber = table.Column<string>(type: "text", nullable: true),
                    ShenasnameSerialLetter = table.Column<string>(type: "text", nullable: true),
                    ShenasnameSerie = table.Column<string>(type: "text", nullable: true),
                    ShenasnameSerial = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BirthPlaceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShenasnameIssuedPlaceId = table.Column<Guid>(type: "uuid", nullable: false),
                    InsurranceCode = table.Column<string>(type: "text", nullable: true),
                    InsurranceStatus = table.Column<string>(type: "text", nullable: true),
                    HasInsurance = table.Column<bool>(type: "boolean", nullable: true),
                    ExtraInsurranceCount = table.Column<int>(type: "integer", nullable: true),
                    JobTitleId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmploymentTypeDisplay = table.Column<int>(type: "integer", nullable: true),
                    StartingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LeavingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SupervisorId = table.Column<Guid>(type: "uuid", nullable: true),
                    InternalContactNumber = table.Column<string>(type: "text", nullable: true),
                    LandPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    MostRecentDegree = table.Column<string>(type: "text", nullable: true),
                    Major = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Cities_BirthPlaceId",
                        column: x => x.BirthPlaceId,
                        principalSchema: "hr",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Cities_ShenasnameIssuedPlaceId",
                        column: x => x.ShenasnameIssuedPlaceId,
                        principalSchema: "hr",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalSchema: "hr",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalSchema: "hr",
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    BankNameId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: true),
                    Iban = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_BankNameList_BankNameId",
                        column: x => x.BankNameId,
                        principalSchema: "hr",
                        principalTable: "BankNameList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "hr",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChequePromissionaryNotes",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequePromissionaryNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChequePromissionaryNotes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "hr",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackJobTitleAndLeaveHistories",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    JobTitle = table.Column<string>(type: "text", nullable: true),
                    StartedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LeftDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackJobTitleAndLeaveHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackJobTitleAndLeaveHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "hr",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankNameId",
                schema: "hr",
                table: "BankAccounts",
                column: "BankNameId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_EmployeeId",
                schema: "hr",
                table: "BankAccounts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankNameList_Name",
                schema: "hr",
                table: "BankNameList",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChequePromissionaryNotes_EmployeeId",
                schema: "hr",
                table: "ChequePromissionaryNotes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                schema: "hr",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BirthPlaceId",
                schema: "hr",
                table: "Employees",
                column: "BirthPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCode",
                schema: "hr",
                table: "Employees",
                column: "EmployeeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                schema: "hr",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalId",
                schema: "hr",
                table: "Employees",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShenasnameIssuedPlaceId",
                schema: "hr",
                table: "Employees",
                column: "ShenasnameIssuedPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupervisorId",
                schema: "hr",
                table: "Employees",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_DepartmentId",
                schema: "hr",
                table: "JobTitles",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackJobTitleAndLeaveHistories_EmployeeId",
                schema: "hr",
                table: "TrackJobTitleAndLeaveHistories",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "ChequePromissionaryNotes",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "TrackJobTitleAndLeaveHistories",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "BankNameList",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "JobTitles",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "hr");
        }
    }
}
