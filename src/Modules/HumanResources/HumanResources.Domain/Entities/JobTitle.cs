using HumanResources.Domain.Interfaces;

namespace HumanResources.Domain.Entities;

public class JobTitle:ISoftDelete
{
    public Guid Id { get; set; }
    public string? Title { get; set; } 
    public Guid DepartmentId { get; set; } 
    public Department? Department { get; set; } 
    public ICollection<Employee> Employees { get; set; } = [];

    public bool IsDeleted { get; set; }=false;
}
