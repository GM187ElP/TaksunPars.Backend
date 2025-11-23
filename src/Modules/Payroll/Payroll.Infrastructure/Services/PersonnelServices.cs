using Microsoft.EntityFrameworkCore;
using TaksunPars.Application.Services;
using TaksunPars.Core.Entities;
using TaksunPars.Infrastructure.Data;

namespace Payroll.Infrastructure.Services;

public class PersonnelServices : IPersonnelServices
{
    private readonly AppDbContext _dbContext;

    public PersonnelServices(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Personnel?> GetPersonnelByPersonnelCodeAsync(string personnelCode)
    {
        return await _dbContext.Personnel
            .FirstOrDefaultAsync(p => p.PersonnelCode == personnelCode);
    }
}