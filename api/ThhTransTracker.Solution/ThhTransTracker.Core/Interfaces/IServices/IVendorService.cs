namespace ThhTransTracker.Core.Interfaces.IServices
{
    public interface IVendorService
    {
        Task<Result<PagedList<VendorDto>>> GetVendors(VendorParam vendorParam);
        Task<Result<VendorDto>> GetVendor(Guid vendorId);
        Task<Result<string>> CreateVendors(IEnumerable<CreateVendorDto> createVendorDtos, string userId);
        Task<Result<VendorDto>> UpdateVendor(UpdateVendorDto updateVendorDto, string userId);
        Task<Result<bool>> DeleteVendor(Guid vendorId);
    }
}
