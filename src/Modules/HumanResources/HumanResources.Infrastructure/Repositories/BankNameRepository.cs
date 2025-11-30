using HumanResources.Application.Interfaces;
using HumanResources.Domain.Entities;
using HumanResources.Infrastructure.Persistence;
using Shared;

namespace HumanResources.Infrastructure.Repositories;

public class BankNameRepository : IBankNameRepository
{
    private readonly HumanResourcesDbContext _db;

    public BankNameRepository(HumanResourcesDbContext db)
    {
        _db = db;
    }

    public Task<ResultStatus> AddAsync(BankName bankName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    //public async Task<ResultStatus> AddAsync(BankName bankName,CancellationToken cancellationToken)
    //{
    //    var result=new ResultStatus();
    //    var bankExists = _db.BankNames.Any(b => b.Name == bankName.Name);
    //    if (bankExists)
    //    {
    //        result.Errors.Add("Bank name already exists.");
    //        result.IsPartialySuccess = true;
    //        return result;
    //    }

    //    await _db.AddAsync(bankName.);
    //    var changesCount=await _db.SaveChangesAsync();
    //    if (changesCount > 0) 
    //        result.IsPartialySuccess = true;
    //    else
    //        result.Errors.Add("Failed to add bank name.");
    //    return result;
    //}
}
