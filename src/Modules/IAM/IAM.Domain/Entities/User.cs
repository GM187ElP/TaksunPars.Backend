using IAM.Domain.Interfaces;

namespace IAM.Domain.Entities;

public class User:ISoftDelete
{
    public Guid Id { get; set; }
    public string? Username { get; set; } // NationalId
    public string? PasswordHash { get; set; }
    public string? ConcurrencyStamp { get; set; }
    public bool IsDeleted { get; set; } = false;

    public ICollection<UserRole> UserRoles { get; set; } = [];

    public Guid PersonnelId { get; set; }
}
