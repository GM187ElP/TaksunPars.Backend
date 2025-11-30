using HumanResources.Application.Interfaces;
using HumanResources.Domain.Entities;
using HumanResources.Infrastructure.Persistence;
using Shared;

namespace HumanResources.Infrastructure.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly HumanResourcesDbContext _db;

    public BankAccountRepository(HumanResourcesDbContext db)
    {
        _db = db;
    }

    public async Task<ResultStatus> AddAsync(BankAccount bankAccount, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

//    public Guid Id { get; set; }
//    public string AccountNumber { get; set; } = string.Empty;
//    public int BankNameId { get; set; }
//    public BankName? BankName { get; set; }
//    public long EmployeeId { get; set; }
//    public Employee? Employee { get; set; }
//    public bool IsMain { get; set; }
//    public string Iban { get; set; } = string.Empty;
//    public bool IsDeleted { get; set; } = false;
//}