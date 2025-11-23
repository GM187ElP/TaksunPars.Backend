using TaksunPars.Core.Entities;

namespace Payroll.Application.Services;

public interface IPersonnelServices
{
    Task<Personnel?> GetPersonnelByPersonnelCodeAsync(string personnelCode);
}