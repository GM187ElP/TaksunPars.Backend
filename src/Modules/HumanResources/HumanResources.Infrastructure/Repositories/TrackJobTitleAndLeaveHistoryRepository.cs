
using HumanResources.Domain.Interfaces;
using HumanResources.Infrastructure.Persistence;

namespace HumanResources.Infrastructure.Repositories;

public class TrackJobTitleAndLeaveHistoryRepository : ITrackJobTitleAndLeaveHistoryRepository
{
    private readonly HumanResourcesDbContext _db;

    public TrackJobTitleAndLeaveHistoryRepository(HumanResourcesDbContext db)
    {
        _db = db;
    }
}
