using Shared.Interfaces;

namespace HumanResources.Domain.Entities;

public class StartLeaveHistory:ISoftDelete
{
    public long Id { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public DateTime StartedDate { get; set; }
    public DateTime LeftDate { get; set; }
    public long EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public bool IsDeleted { get; set; }
}
