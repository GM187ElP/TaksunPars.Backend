using Shared.Interfaces;

namespace HumanResources.Domain.Entities;

public class BankAccount:ISoftDelete
{
    public long Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public int BankNameId { get; set; }
    public BankName? BankName { get; set; } 
    public long EmployeeId { get; set; }
    public Employee? Employee { get; set; } 
    public bool IsMain { get; set; }
    public string Iban { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
}
