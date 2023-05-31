using ThhTransTracker.Core.Entities;

namespace ThhTransTracker.Infrastructure.Implementations.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly EfCoreDbContext _dbContext;

        public ShipperRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateShipper(Shipper shipper)
        {
            var result = _dbContext.Shippers.Add(shipper); await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> DeleteShipper(Guid shipperId)
        {
            var shipper = await _dbContext.Shippers.Where(x => x.Id == shipperId).FirstOrDefaultAsync();
            if (shipper == null)
            {
                throw new NotFoundException($"Shipper with id {shipperId} was not found");
            }
            _dbContext.Shippers.Remove(shipper);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Shipper> GetShipper(Guid shipperId)
        {
            var shipper = await _dbContext.Shippers.Where(x => x.Id == shipperId).FirstOrDefaultAsync();
            if (shipper == null)
            {
                throw new NotFoundException($"Shipper with id {shipperId} was not found");
            }
            return shipper;
        }

        public async Task<PagedList<Shipper>> GetShippers(ShipperParam shipperParam)
        {
            var source = _dbContext.Shippers.AsNoTracking();

            var result = await PagedList<Shipper>
                .ToPagedListAsync(source, shipperParam.PageNumber, shipperParam.PageSize);

            return result;
        }

        public async Task<Shipper> UpdateShipper(Shipper shipper)
        {
            var existingShipper = await _dbContext.Shippers.Where(x => x.Id == shipper.Id).FirstOrDefaultAsync();
            if (existingShipper == null)
            {
                throw new NotFoundException($"Shipper with id {shipper.Id} was not found");
            }
            var result = _dbContext.Shippers.Update(shipper); await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
