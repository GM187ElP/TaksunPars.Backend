using System;
using System.Collections.Generic;
using System.Text;

namespace IAM.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } // NationalId
    public  string PasswordHash { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

    public Guid PersonnelId { get; set; }
}
