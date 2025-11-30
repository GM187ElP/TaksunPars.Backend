using HumanResources.Application.Interfaces;
using HumanResources.Domain.Entities;
using HumanResources.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace HumanResources.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly HumanResourcesDbContext _db;
    private readonly ITrackJobTitleAndLeaveHistoryRepository _trackJobTitleAndLeaveHistoryRepository;
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IChequePromissionaryNoteRepository _chequePromissionaryNoteRepository;

    public EmployeeRepository(HumanResourcesDbContext db,
        ITrackJobTitleAndLeaveHistoryRepository trackJobTitleAndLeaveHistoryRepository,
        IBankAccountRepository bankAccountRepository,
        IChequePromissionaryNoteRepository chequePromissionaryNoteRepository)
    {
        _db = db;
        _trackJobTitleAndLeaveHistoryRepository = trackJobTitleAndLeaveHistoryRepository;
        _bankAccountRepository = bankAccountRepository;
        _chequePromissionaryNoteRepository = chequePromissionaryNoteRepository;
    }

    public async Task<ResultStatus> AddAsync(Employee employee, CancellationToken cancellationToken)
    {
        await _db.Employees.AddAsync(employee, cancellationToken);
        var changesCount = await _db.SaveChangesAsync(cancellationToken);

        var result = new ResultStatus();
        if (changesCount > 0)
            result.IsPartialySuccess = true;
        else
            result.IsPartialySuccess = false;
        return result;
    }

    public async Task<Guid?> GetEmployeeIdByCodeAsync(string code, CancellationToken cancellationToken)
    {
        return await _db.Employees
            .Where(e => e.EmployeeCode == code)
            .AsNoTracking()
            .Select(e => e.Id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Guid?> GetEmployeeIdByNationalIdAsync(string nationalId, CancellationToken cancellationToken)
    {
        var employee=await _db.Employees.AsNoTracking()
            .FirstOrDefaultAsync(x => x.NationalId == nationalId);

        return employee?.Id;
    }
}

