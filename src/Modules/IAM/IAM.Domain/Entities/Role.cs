using IAM.Domain.Interfaces;

namespace IAM.Domain.Entities;

public class Role : ISoftDelete
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? NormalizedName { get; set; }
    public string? ConcurrencyStamp { get; set; }
    public bool IsDeleted { get; set; } = false;

    public ICollection<UserRole> UserRoles { get; set; } = [];
}
