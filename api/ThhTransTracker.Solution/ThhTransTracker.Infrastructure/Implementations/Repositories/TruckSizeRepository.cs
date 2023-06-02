using ThhTransTracker.Core.Entities;

namespace ThhTransTracker.Infrastructure.Implementations.Repositories
{
    public class TruckSizeRepository : ITruckSizeRepository
    {
        private readonly EfCoreDbContext _dbContext;

        public TruckSizeRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateTruckSizes(IEnumerable<TruckSize> truckSizes)
        {
            _dbContext.TruckSizes.AddRange(truckSizes);
            int numOfRows = await _dbContext.SaveChangesAsync();
            return $"{numOfRows} truck sizes added";
        }

        public async Task<bool> DeleteTruckSizes(Guid truckSizeId)
        {
            var truckSize = await _dbContext.TruckSizes.Where(x => x.Id == truckSizeId).FirstOrDefaultAsync();
            if (truckSize == null)
            {
                throw new NotFoundException($"Truck size with id {truckSizeId} not found");
            }
            _dbContext.TruckSizes.Remove(truckSize);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<PagedList<TruckSize>> GetTruckSizes(TruckSizeParam truckSizeParam)
        {
            var source = _dbContext.TruckSizes.AsNoTracking();

            if (truckSizeParam.MinimumSize != 0)
            {
                source = source.Where(x => x.Size >= truckSizeParam.MinimumSize);
            }

            return await PagedList<TruckSize>
                .ToPagedListAsync(source, truckSizeParam.PageNumber, truckSizeParam.PageSize);
        }

        public async Task<TruckSize> UpdateTruckSize(TruckSize truckSize)
        {
            var existingTruckSize = await _dbContext.TruckSizes.Where(x => x.Id == truckSize.Id).FirstOrDefaultAsync();
            if (existingTruckSize == null)
            {
                throw new NotFoundException($"Truck size with id {truckSize.Id} not found");
            }
            var result = _dbContext.TruckSizes.Update(truckSize);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
