namespace ThhTransTracker.Core.Interfaces.IServices
{
    public interface IVendorPriceService
    {
        Task<Result<PagedList<VendorPriceDto>>> GetVendorPrices(VendorPriceParam vendorPriceParam, Guid vendorId);
        Task<Result<string>> CreateVendorPrices(IEnumerable<CreateVendorPriceDto> createVendorPriceDtos, string userId);
        Task<Result<VendorPriceDto>> UpdateVendorPrice(UpdateVendorPriceDto updateVendorPriceDto, string userId);
        Task<Result<bool>> DeleteVendorPrice(Guid vendorPriceId);
    }
}
