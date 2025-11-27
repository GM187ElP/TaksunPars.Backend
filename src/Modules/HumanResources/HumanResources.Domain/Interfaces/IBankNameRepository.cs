using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Domain.Interfaces;

public interface IBankNameRepository
{
    Task<ResultStatus> AddAsync(BankName bankName,CancellationToken cancellationToken);
}
