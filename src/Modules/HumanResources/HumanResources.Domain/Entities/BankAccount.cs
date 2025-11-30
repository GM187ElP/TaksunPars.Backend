using HumanResources.Domain.Interfaces;

namespace HumanResources.Domain.Entities;

public class BankAccount:ISoftDelete
{
    public Guid Id { get; set; }
    public string? AccountNumber { get; set; } 
    public Guid BankNameId { get; set; }
    public BankName? BankName { get; set; } 
    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; } 
    public bool? IsMain { get; set; }
    public string? Iban { get; set; } 
    public bool IsDeleted { get; set; } = false;
}
