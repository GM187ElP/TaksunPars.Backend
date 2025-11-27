using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Domain.Interfaces;

public interface IBankAccountRepository
{
    Task<ResultStatus> AddAsync(BankAccount bankAccount, CancellationToken cancellationToken);
}
