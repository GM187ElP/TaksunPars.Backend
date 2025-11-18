using TaksunPars.Core.Entities;

namespace TaksunPars.Application.Services;

public interface IPersonnelServices
{
    Task<Personnel?> GetPersonnelByPersonnelCodeAsync(string personnelCode);
}