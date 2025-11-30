using IAM.Domain.Entities;

namespace IAM.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid Id);
    Task AddAsync(User user);
    Task LoginAsync(User user);
    void Logout();
    Task<User?> FindByUsernameAsync(string username);
}