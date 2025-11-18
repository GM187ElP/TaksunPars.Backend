namespace TaksunPars.Core.Entities;

public class Personnel
{
    public Guid Id { get; set; }
    public string PersonnelCode { get; set; } // کد پرسنلی
    public string NationalId { get; set; } // کد ملی
    public string FirstName { get; set; } // نام
    public string LastName { get; set; } // نام خانوادگی
    public string? MobileNumber { get; set; } // موبایل
    public string? AccountingNumber { get; set; } // شماره حساب
    public Guid DepartmentId { get; set; } // شناسه دپارتمان

    // Navigation properties
    public User? User { get; set; }
    public Department Department { get; set; }
    public ICollection<Payslip> PaySlips { get; set; } = new List<Payslip>();
}