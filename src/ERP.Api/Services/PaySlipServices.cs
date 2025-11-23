

using ERP.Api.Services;
using TaksunPars.Application.DTOs;
using TaksunPars.Core.Entities;

namespace TaksunPars.Api.Services;

public partial class PayslipServices: IPayslipServices
{
    public DownloadPayslipDto ToDto(Payslip p)
    {
        return new DownloadPayslipDto
        {
            Id = p.Id,
            PersonnelCode = p.PersonnelCode,
            PersonnelId = p.PersonnelId,

            FirstName = p.Personnel?.FirstName,
            LastName = p.Personnel?.LastName,
            Department = p.Personnel?.Department.Name,
            AccountNumber=p.Personnel?.AccountingNumber,

            Year = p.Year,
            Month = p.Month,

            DailySalary = p.DailySalary,
            WorkingDays = p.WorkingDays,
            MonthlyBaseSalary = p.MonthlyBaseSalary,

            WorkerBenefit = p.WorkerBenefit,
            HousingAllowance = p.HousingAllowance,
            ChildAllowance = p.ChildAllowance,
            FamilyOrFuelAllowance = p.FamilyOrFuelAllowance,
            LunchAllowance = p.LunchAllowance,
            MissionAllowance = p.MissionAllowance,
            MobileAllowance = p.MobileAllowance,
            CommissionOvertime = p.CommissionOvertime,
            ResponsibilityAllowance = p.ResponsibilityAllowance,
            OtherBenefits = p.OtherBenefits,

            TotalSalaryAndBenefits = p.TotalSalaryAndBenefits,

            InsuranceWorkerShare = p.InsuranceWorkerShare,
            SupplementaryInsurance = p.SupplementaryInsurance,
            SalaryTax = p.SalaryTax,
            OnePerThousandInsurance = p.OnePerThousandInsurance,

            FundLoanDeducted = p.FundLoanDeducted,
            FundLoanRemaining = p.FundLoanRemaining,
            CompanyLoanDeducted = p.CompanyLoanDeducted,
            CompanyLoanRemaining = p.CompanyLoanRemaining,

            DebtToCompany = p.DebtToCompany,
            PaidLeaveInDays = p.PaidLeaveInDays,
            UnpaidLeaveInDays = p.UnpaidLeaveInDays,

            CommissionReserve = p.CommissionReserve,
            TotalDeductions = p.TotalDeductions,

            GrossReceivable = p.GrossReceivable,
            InsuranceAndTaxDeductions = p.InsuranceAndTaxDeductions,
            NetReceivable = p.NetReceivable,
            CompanyDeductions = p.CompanyDeductions,
            NetPayable = p.NetPayable
        };
    }




}
