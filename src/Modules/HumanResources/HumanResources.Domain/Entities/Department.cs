using HumanResources.Domain.Interfaces;

namespace HumanResources.Domain.Entities;

public class Department : ISoftDelete
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public ICollection<JobTitle> JobTitles { get; set; } = [];
    public bool IsDeleted { get; set; } = false;
}