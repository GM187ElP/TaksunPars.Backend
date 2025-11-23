using TaksunPars.Core.Entities;

namespace Payroll.Application.Services;

public interface IAuthServices
{
    Task<string> LoginAsync(string username, string password);
    Task<User?> GetUserByUsernameAsync(string username);
}