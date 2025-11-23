using System.ComponentModel.DataAnnotations;

namespace Payroll.Application.DTOs;

public class LoginDto
{
    [Required] [Length(10, 10)] public required string Username { get; set; }

    [Required] public required string Password { get; set; }
}