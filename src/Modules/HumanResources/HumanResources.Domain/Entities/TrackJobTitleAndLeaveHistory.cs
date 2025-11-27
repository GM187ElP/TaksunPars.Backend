using Shared.Interfaces;

namespace HumanResources.Domain.Entities;

public class TrackJobTitleAndLeaveHistory:ISoftDelete
{
    public Guid Id { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public DateTime StartedDate { get; set; }
    public DateTime LeftDate { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public bool IsDeleted { get; set; }
}
