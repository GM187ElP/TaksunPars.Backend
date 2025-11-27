using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces;
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
        var result = new ResultStatus();
        await _db.Employees.AddAsync(employee, cancellationToken);
        var changesCount = await _db.SaveChangesAsync(cancellationToken);
        if (changesCount > 0)
            result.IsPartialySuccess = true;
        else
            result.IsPartialySuccess = false;
        return result;
    }

    public async Task<Guid?> GetEmployeeIdByCodeAsync(string code, CancellationToken ct)
    {
        return await _db.Employees
            .Where(e => e.EmployeeCode == code)
            .AsNoTracking()
            .Select(e => e.Id)
            .FirstOrDefaultAsync(ct);
    }
}

