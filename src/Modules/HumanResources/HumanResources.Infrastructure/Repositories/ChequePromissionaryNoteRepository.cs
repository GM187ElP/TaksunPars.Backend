using HumanResources.Application.Interfaces;
using HumanResources.Infrastructure.Persistence;

namespace HumanResources.Infrastructure.Repositories;

public class ChequePromissionaryNoteRepository:IChequePromissionaryNoteRepository
{
    private readonly HumanResourcesDbContext _db;

    public ChequePromissionaryNoteRepository(HumanResourcesDbContext db)
    {
        _db = db;
    }
}
