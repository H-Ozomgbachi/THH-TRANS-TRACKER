namespace ThhTransTracker.Infrastructure.Implementations.Repositories
{
    public class ShipperPriceRepository : IShipperPriceRepository
    {
        private readonly EfCoreDbContext _dbContext;

        public ShipperPriceRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateShipperPrices(IEnumerable<ShipperPrice> shipperPrices)
        {
            _dbContext.AddRange(shipperPrices);
            int dbRows = await _dbContext.SaveChangesAsync();
            return $"{dbRows} records of shipper price added.";
        }

        public async Task<bool> DeleteShipperPrice(Guid shipperPriceId)
        {
            ShipperPrice shipperPrice = await _dbContext.ShipperPrices.Where(x => x.Id== shipperPriceId).FirstOrDefaultAsync();

            if (shipperPrice == null)
            {
                throw new NotFoundException($"Shipper price with id:{shipperPriceId} not found!");
            }

            _dbContext.Remove(shipperPrice);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<PagedList<ShipperPrice>> GetShipperPrices(ShipperPriceParam shipperPriceParam, Guid shipperId)
        {
            var source = _dbContext.ShipperPrices.Where(x => x.ShipperId == shipperId);

            return await PagedList<ShipperPrice>
                .ToPagedListAsync(source, shipperPriceParam.PageNumber, shipperPriceParam.PageSize);
        }

        public async Task<ShipperPrice> UpdateShipperPrice(ShipperPrice shipperPrice)
        {
            ShipperPrice existingShipperPrice = await _dbContext.ShipperPrices.Where(x => x.Id == shipperPrice.Id).FirstOrDefaultAsync();

            if (shipperPrice == null)
            {
                throw new NotFoundException($"Shipper price with id:{shipperPrice.Id} not found!");
            }

            var result = _dbContext.ShipperPrices.Update(shipperPrice);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
