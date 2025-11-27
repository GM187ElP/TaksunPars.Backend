using Shared.Interfaces;

namespace HumanResources.Domain.Entities;

public class BankName : ISoftDelete
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
}
