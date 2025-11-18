using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TaksunPars.Application.Services;
using TaksunPars.Core.Entities;
using TaksunPars.Infrastructure.Data;
using TaksunPars.Shared;

namespace TaksunPars.Infrastructure.Services;

public class PaySlipServices(AppDbContext dbContext, IPersonnelServices personnelServices) : IPaySlipServices
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IPersonnelServices _personnelServices = personnelServices;

    public async Task<Result> UploadAsync(IFormFile paySlipFile)
    {
        using var workbook = new XLWorkbook(paySlipFile.OpenReadStream());

        var ws = workbook.Worksheet(1);

        var result = new Result();

        var year = ParseInt(ws.Cell(1, 1).GetString()).ToString();
        var month = ParseInt(ws.Cell(2, 1).GetString()).ToString();

        if (year == "0" || month == "0")
        {
            result.Errors.Add("ماه و سال وارد شده معتبر نمی‌باشد.");
            return result;
        }

        var rows = ws.RangeUsed()?.RowsUsed().Skip(1).ToList();

        var payslips = new List<Payslip>();

        if (rows != null)
            foreach (var row in rows)
            {
                var payslip = new Payslip();

                var pc = ParseInt(row.Cell(3).GetString()).ToString();
                if (pc == "0")
                {
                    result.Errors.Add($"کد پرسنلی وارد شده ردیف {rows.IndexOf(row) + 1} معتبر نمی‌باشد.");
                    continue;
                }

                var p = await _personnelServices.GetPersonnelByPersonnelCodeAsync(pc);
                if (p == null)
                {
                    result.Errors.Add($"پرسنل با کد {pc} یافت نشد.");
                    continue;
                }

                payslip.Year = year;
                payslip.Month = month;
                payslip.PersonnelCode = pc;
                payslip.PersonnelId = p.Id;
                payslip.DailySalary = ParseLong(row.Cell(4).GetString());
                payslip.WorkingDays = ParseInt(row.Cell(5).GetString());
                payslip.MonthlyBaseSalary = ParseLong(row.Cell(6).GetString());
                payslip.WorkerBenefit = ParseLong(row.Cell(7).GetString());
                payslip.HousingAllowance = ParseLong(row.Cell(8).GetString());
                payslip.ChildAllowance = ParseLong(row.Cell(9).GetString());
                payslip.FamilyOrFuelAllowance = ParseLong(row.Cell(10).GetString());
                payslip.LunchAllowance = ParseLong(row.Cell(11).GetString());
                payslip.MissionAllowance = ParseLong(row.Cell(12).GetString());
                payslip.MobileAllowance = ParseLong(row.Cell(13).GetString());
                payslip.CommissionOvertime = ParseLong(row.Cell(14).GetString());
                payslip.ResponsibilityAllowance = ParseLong(row.Cell(15).GetString());
                payslip.OtherBenefits = ParseLong(row.Cell(16).GetString());
                payslip.TotalSalaryAndBenefits = ParseLong(row.Cell(17).GetString());
                payslip.InsuranceWorkerShare = ParseLong(row.Cell(18).GetString());
                payslip.SupplementaryInsurance = ParseLong(row.Cell(19).GetString());
                payslip.SalaryTax = ParseLong(row.Cell(20).GetString());
                payslip.OnePerThousandInsurance = ParseLong(row.Cell(21).GetString());
                payslip.FundLoanDeducted = ParseLong(row.Cell(22).GetString());
                payslip.FundLoanRemaining = ParseLong(row.Cell(23).GetString());
                payslip.CompanyLoanDeducted = ParseLong(row.Cell(24).GetString());
                payslip.CompanyLoanRemaining = ParseLong(row.Cell(25).GetString());
                payslip.DebtToCompany = ParseLong(row.Cell(26).GetString());
                payslip.PaidLeaveInDays = ParseInt(row.Cell(27).GetString());
                payslip.UnpaidLeaveInDays = ParseInt(row.Cell(28).GetString());
                payslip.CommissionReserve = ParseLong(row.Cell(29).GetString());
                payslip.TotalDeductions = ParseLong(row.Cell(30).GetString());
                payslip.GrossReceivable = ParseLong(row.Cell(31).GetString());
                payslip.InsuranceAndTaxDeductions = ParseLong(row.Cell(32).GetString());
                payslip.NetReceivable = ParseLong(row.Cell(33).GetString());
                payslip.CompanyDeductions = ParseLong(row.Cell(34).GetString());
                payslip.NetPayable = ParseLong(row.Cell(35).GetString());

                var existingPayslip = await _dbContext.Payslips
                    .FirstOrDefaultAsync(ps =>
                        ps.PersonnelCode == pc &&
                        ps.Year == year &&
                        ps.Month == month);

                if (existingPayslip != null)
                {
                    result.Errors.Add($"فیش حقوقی پرسنل {pc} برای {year}/{month} قبلاً ثبت شده است.");
                    continue;
                }

                payslips.Add(payslip);
            }

        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            _dbContext.Payslips.AddRange(payslips);
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            result.IsPartialySuccess = true;
            return result;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            result.Errors.Add($"خطا در ذخیره‌سازی: {ex.Message}");
            return result;
        }
    }

    private int ParseInt(string input)
    {
        return int.TryParse(input, out var i) ? i : 0;
    }

    private long ParseLong(string input)
    {
        return long.TryParse(input, out var i) ? i : 0;
    }
}