namespace HumanResources.Domain.Entities;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<JobTitle> JobTitles { get; set; }
}