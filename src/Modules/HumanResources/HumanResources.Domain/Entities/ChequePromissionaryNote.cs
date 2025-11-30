using HumanResources.Domain.Enums;
using HumanResources.Domain.Interfaces;

namespace HumanResources.Domain.Entities;

public class ChequePromissionaryNote : ISoftDelete
{
    public Guid Id { get; set; }
    public string? Number { get; set; }
    public NoteType? Type { get; set; }
    public long? Amount { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public bool IsDeleted { get; set; } = false;
}
