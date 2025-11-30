using HumanResources.Domain.Entities;
using Shared;

namespace HumanResources.Application.Interfaces;

public interface IBankNameRepository
{
    Task<ResultStatus> AddAsync(BankName bankName,CancellationToken cancellationToken);
}
