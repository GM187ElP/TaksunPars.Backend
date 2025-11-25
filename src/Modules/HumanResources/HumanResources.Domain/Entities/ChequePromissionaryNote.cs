using HumanResources.Domain.Enums;
using Shared.Interfaces;

namespace HumanResources.Domain.Entities;

public class ChequePromissionaryNote : ISoftDelete
{
    public long Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public NoteType Type { get; set; }
    public long Amount { get; set; }
    public long EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public bool IsDeleted { get; set; } = false;
}
