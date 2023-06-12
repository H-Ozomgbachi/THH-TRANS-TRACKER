namespace ThhTransTracker.Core.Interfaces.IRepositories
{
    public interface IVendorRepository
    {
        Task<PagedList<Vendor>> GetVendors(VendorParam vendorParam);
        Task<Vendor> GetVendor(Guid vendorId);
        Task<string> CreateVendors(IEnumerable<Vendor> vendors);
        Task<Vendor> UpdateVendor(Vendor vendor);
        Task<bool> DeleteVendor(Guid vendorId);
    }
}
