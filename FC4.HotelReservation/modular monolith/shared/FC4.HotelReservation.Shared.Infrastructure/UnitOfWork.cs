using FC4.HotelReservation.Shared.Application;
using FC4.HotelReservation.Shared.Domain;
using MediatR;

namespace FC4.HotelReservation.Shared.Infrastructure;

public class UnitOfWork(HotelDbContext dbContext) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}