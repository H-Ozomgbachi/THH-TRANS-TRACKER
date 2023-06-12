namespace ThhTransTracker.Infrastructure.Implementations.Repositories
{
    public class VendorPriceRepository : IVendorPriceRepository
    {
        private readonly EfCoreDbContext _dbContext;

        public VendorPriceRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateVendorPrices(IEnumerable<VendorPrice> vendorPrices)
        {
            _dbContext.VendorPrices.AddRange(vendorPrices);
            int dbRows = await _dbContext.SaveChangesAsync();
            return $"{dbRows} vendor prices record(s) created!";
        }

        public async Task<bool> DeleteVendorPrice(Guid vendorPriceId)
        {
            var vendorPrice = await _dbContext.VendorPrices.Where(x => x.Id == vendorPriceId).FirstOrDefaultAsync();

            if (vendorPrice == null)
            {
                throw new NotFoundException($"Vendor price with id : {vendorPriceId} not found!");
            }
            _dbContext.Remove(vendorPrice);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<PagedList<VendorPrice>> GetVendorPrices(VendorPriceParam vendorPriceParam, Guid vendorId)
        {
            var source = _dbContext.VendorPrices.Where(x => x.VendorId == vendorId);

            return await PagedList<VendorPrice>
                .ToPagedListAsync(source, vendorPriceParam.PageNumber, vendorPriceParam.PageSize);
        }

        public async Task<VendorPrice> UpdateVendorPrice(VendorPrice vendorPrice)
        {
            var exisitingVendorPrice = await _dbContext.VendorPrices.Where(x => x.Id == vendorPrice.Id).FirstOrDefaultAsync();

            if (vendorPrice == null)
            {
                throw new NotFoundException($"Vendor price with id : {vendorPrice.Id} not found!");
            }

            var result = _dbContext.VendorPrices.Update(vendorPrice);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
