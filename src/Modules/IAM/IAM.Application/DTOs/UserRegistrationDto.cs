using Shared;

namespace IAM.Application.DTOs;

public class UserRegistrationDto
{
    [EntityInfo("Username")]
    public string Username { get; set; }
    [EntityInfo("Password")]
    public string Password { get; set; }
}
