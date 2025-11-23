using Microsoft.EntityFrameworkCore;
using TaksunPars.Application.Services;
using TaksunPars.Core.Entities;
using TaksunPars.Infrastructure.Data;

namespace Payroll.Infrastructure.Services;

public class AuthServices : IAuthServices
{
    private readonly AppDbContext _dbContext;

    public AuthServices(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _dbContext.Users
            .Include(u => u.Personnel)
            .FirstOrDefaultAsync(u => u.Username == username);
    }
}