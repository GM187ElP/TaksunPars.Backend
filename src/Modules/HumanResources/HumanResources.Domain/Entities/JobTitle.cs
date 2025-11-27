using Shared.Interfaces;

namespace HumanResources.Domain.Entities;

public class JobTitle:ISoftDelete
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; } 
    public Department Department { get; set; } 
    public ICollection<JobTitle> JobTitles { get; set; } = [];
    public ICollection<Employee> Employees { get; set; } = [];

    public bool IsDeleted { get; set; }
}
