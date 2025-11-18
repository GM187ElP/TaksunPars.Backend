using TaksunPars.Core.Entities;

namespace TaksunPars.Application.Services;

public interface IAuthServices
{
    Task<string> LoginAsync(string username, string password);
    Task<User?> GetUserByUsernameAsync(string username);
}