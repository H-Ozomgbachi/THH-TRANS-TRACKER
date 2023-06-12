namespace ThhTransTracker.Core.Interfaces.IRepositories
{
    public interface IVendorPriceRepository
    {
        Task<PagedList<VendorPrice>> GetVendorPrices(VendorPriceParam vendorPriceParam, Guid vendorId);
        Task<string> CreateVendorPrices(IEnumerable<VendorPrice> vendorPrices);
        Task<VendorPrice> UpdateVendorPrice(VendorPrice vendorPrice);
        Task<bool> DeleteVendorPrice(Guid vendorPriceId);
    }
}
