namespace ThhTransTracker.Infrastructure.Implementations.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly EfCoreDbContext _dbContext;

        public VendorRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateVendors(IEnumerable<Vendor> vendors)
        {
            _dbContext.Vendors.AddRange(vendors);
            int dbRows = await _dbContext.SaveChangesAsync();
            return $"{dbRows} vendor record(s) created!";
        }

        public async Task<bool> DeleteVendor(Guid vendorId)
        {
            var vendor = await _dbContext.Vendors.Where(x => x.Id == vendorId).FirstOrDefaultAsync();
            if (vendor == null)
            {
                throw new NotFoundException($"Vendor with id : {vendorId} was not found");
            }
            _dbContext.Vendors.Remove(vendor);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Vendor> GetVendor(Guid vendorId)
        {
            var vendor = await _dbContext.Vendors.Where(x => x.Id == vendorId).FirstOrDefaultAsync();
            if (vendor == null)
            {
                throw new NotFoundException($"Vendor with id : {vendorId} was not found");
            }
            return vendor;
        }

        public async Task<PagedList<Vendor>> GetVendors(VendorParam vendorParam)
        {
            var source = _dbContext.Vendors;

            return await PagedList<Vendor>
                .ToPagedListAsync(source, vendorParam.PageNumber, vendorParam.PageSize);
        }

        public async Task<Vendor> UpdateVendor(Vendor vendor)
        {
            var existingVendor = await _dbContext.Vendors.Where(x => x.Id == vendor.Id).FirstOrDefaultAsync();
            if (vendor == null)
            {
                throw new NotFoundException($"Vendor with id : {vendor.Id} was not found");
            }

            var result = _dbContext.Vendors.Update(vendor);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
