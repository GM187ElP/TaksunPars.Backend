using Shared;

namespace Payroll.Application.DTOs;

public class GetPayslipDto
{
    [EntityInfo("FirstName")]
    public string FirstName { get; set; }
    [EntityInfo("LastName")]
    public string LastName { get; set; }

    [EntityInfo("Id")]
    public Guid Id { get; set; }

    // کد پرسنلی - Personnel Reference
    [EntityInfo("EmployeeCode")]
    public string? EmployeeCode { get; set; } // Common between personnel and payslip

    // سال و ماه
    [EntityInfo("Year")]
    public string? Year { get; set; } // سال
    [EntityInfo("Month")]
    public string? Month { get; set; } // ماه

    // حقوق و دستمزد

    [EntityInfo("DailySalary")]
    public long? DailySalary { get; set; } // حقوق روزانه
    [EntityInfo("WorkingDays")]
    public int? WorkingDays { get; set; } // تعداد روز کاری
    [EntityInfo("MonthlyBaseSalary")]
    public long? MonthlyBaseSalary { get; set; } // حقوق ثابت ماهانه

    // مزایا
    [EntityInfo("WorkerBenefit")]
    public long? WorkerBenefit { get; set; } // بن کارگری
    [EntityInfo("HousingAllowance")]
    public long? HousingAllowance { get; set; } // حق مسکن
    [EntityInfo("ChildAllowance")]
    public long? ChildAllowance { get; set; } // حق اولاد
    [EntityInfo("FamilyOrFuelAllowance")]
    public long? FamilyOrFuelAllowance { get; set; } // حق عائله مندی - سوخت
    [EntityInfo("LunchAllowance")]
    public long? LunchAllowance { get; set; } // حق ناهار
    [EntityInfo("MissionAllowance")]
    public long? MissionAllowance { get; set; } // حق ماموریت
    [EntityInfo("MobileAllowance")]
    public long? MobileAllowance { get; set; } // موبایل
    [EntityInfo("CommissionOvertime")]
    public long? CommissionOvertime { get; set; } // پورسانت - اضافه کاری
    [EntityInfo("ResponsibilityAllowance")]
    public long? ResponsibilityAllowance { get; set; } // حق مسئولیت
    [EntityInfo("OtherBenefits")]
    public long? OtherBenefits { get; set; } // سایر مزایا

    // جمع حقوق و مزایا
    [EntityInfo("TotalSalaryAndBenefits")]
    public long? TotalSalaryAndBenefits { get; set; } // جمع حقوق و مزایا

    // کسورات
    [EntityInfo("InsuranceWorkerShare")]
    public long? InsuranceWorkerShare { get; set; } // بیمه سهم کارگر
    [EntityInfo("SupplementaryInsurance")]
    public long? SupplementaryInsurance { get; set; } // بیمه تکمیلی
    [EntityInfo("SalaryTax")]
    public long? SalaryTax { get; set; } // مالیات حقوق
    [EntityInfo("OnePerThousandInsurance")]
    public long? OnePerThousandInsurance { get; set; } // یک در هزار بیمه

    // وام‌ها
    [EntityInfo("FundLoanDeducted")]
    public long? FundLoanDeducted { get; set; } // وام صندوق کسر شده
    [EntityInfo("FundLoanRemaining")]
    public long? FundLoanRemaining { get; set; } // وام صندوق مانده
    [EntityInfo("CompanyLoanDeducted")]
    public long? CompanyLoanDeducted { get; set; } // وام شرکت کسر شده
    [EntityInfo("CompanyLoanRemaining")]
    public long? CompanyLoanRemaining { get; set; } // وام شرکت مانده

    // بدهی و مرخصی
    [EntityInfo("DebtToCompany")]
    public long? DebtToCompany { get; set; } // بدهی به شرکت
    [EntityInfo("PaidLeaveInDays")]
    public int? PaidLeaveInDays { get; set; } // مرخصی با حقوق (روز)
    [EntityInfo("UnpaidLeaveInDays")]
    public int? UnpaidLeaveInDays { get; set; } // مرخصی بدون حقوق (روز)

    // ذخیره و جمع
    [EntityInfo("CommissionReserve")]
    public long? CommissionReserve { get; set; } // ذخیر پورسانت
    [EntityInfo("TotalDeductions")]
    public long? TotalDeductions { get; set; } // جمع کسورات

    // دریافتی‌ها
    [EntityInfo("GrossReceivable")]
    public long? GrossReceivable { get; set; } // ناخالص دریافتی
    [EntityInfo("InsuranceAndTaxDeductions")]
    public long? InsuranceAndTaxDeductions { get; set; } // کسورات بیمه و مالیات
    [EntityInfo("NetReceivable")]
    public long? NetReceivable { get; set; } // خالص دریافتی
    [EntityInfo("CompanyDeductions")]
    public long? CompanyDeductions { get; set; } // کسورات شرکت
    [EntityInfo("NetPayable")]
    public long? NetPayable { get; set; } // خالص پرداختی


    // مرجع پرسنلی
    [EntityInfo("EmployeeId")]
    public Guid EmployeeId { get; set; }
}
