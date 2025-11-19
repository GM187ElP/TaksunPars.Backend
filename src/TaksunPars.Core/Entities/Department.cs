namespace TaksunPars.Core.Entities;

public class Department
{
    public Guid Id { get; set; }
    public string DepartmentId { get; set; }
    public required string Name { get; set; }

    public ICollection<Personnel> Personnels { get; set; } = new List<Personnel>();
}