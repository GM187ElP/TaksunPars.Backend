using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared;
using TaksunPars.Application.DTOs;
using TaksunPars.Application.Services;
using TaksunPars.Core.Entities;
using TaksunPars.Infrastructure.Data;


namespace TaksunPars.Infrastructure.Services;

public class PaySlipServices(AppDbContext dbContext, IPersonnelServices personnelServices) : IPaySlipServices
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IPersonnelServices _personnelServices = personnelServices;

    public async Task<ResultStatus> UploadAsync(Result<List<Payslip>> payslips)
    {
        foreach
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

    //public async Task<Result> DownloadAsync(string personnelCode, int year, int month)
    //{
    //    var result = new Result();
    //    var payslip = await _dbContext.Payslips.Include(ps=>ps.Personnel).ThenInclude(p=>p.Department)
    //        .FirstOrDefaultAsync(ps =>
    //            ps.PersonnelCode == personnelCode &&
    //            ps.Year == year.ToString() &&
    //            ps.Month == month.ToString());

    //    if (payslip == null)
    //    {
    //        result.Data = null;
    //        return result;
    //    }

    //    result.Data = payslip;
    //    result.IsPartialySuccess = true;
    //    return result;
    //}

    private int ParseInt(string input)
    {
        return int.TryParse(input, out var i) ? i : 0;
    }

    private long ParseLong(string input)
    {
        return long.TryParse(input, out var i) ? i : 0;
    }
}

