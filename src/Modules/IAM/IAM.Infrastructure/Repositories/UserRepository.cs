using IAM.Application.Interfaces;
using IAM.Domain.Entities;
using IAM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IAM.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbSet<User> _db;
    private readonly DbContext _context;

    public UserRepository(IAMDbContext context)
    {
        _context = context;
        _db = context.Set<User>();
    }

    public async Task AddAsync(User user)
    {
        await _db.AddAsync(user);
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await _db.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _db.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task LoginAsync(User user)
    {
        throw new NotImplementedException();
    }

    public void Logout()
    {
        throw new NotImplementedException();
    }
}
