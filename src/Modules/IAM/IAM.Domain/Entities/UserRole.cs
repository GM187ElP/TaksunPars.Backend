using Shared.Interfaces;

namespace IAM.Domain.Entities;

public class UserRole:ISoftDelete
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }

    public bool IsDeleted { get; set; }
}
