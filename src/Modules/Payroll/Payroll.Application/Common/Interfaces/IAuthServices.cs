using IAM.Domain.Entities;

namespace Payroll.Application.Common.Interfaces;

public interface IAuthServices
{
    Task<string> LoginAsync(string username, string password);
    Task<User?> GetUserByUsernameAsync(string username);
}