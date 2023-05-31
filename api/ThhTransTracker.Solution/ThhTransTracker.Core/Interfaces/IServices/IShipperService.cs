namespace ThhTransTracker.Core.Interfaces.IServices
{
    public interface IShipperService
    {
        Task<Result<PagedList<ShipperDto>>> GetShippers(ShipperParam shipperParam);
        Task<Result<ShipperDto>> GetShipper(Guid shipperId);
        Task<Result<Guid>> CreateShipper(CreateShipperDto createShipperDto, string userId);
        Task<Result<ShipperDto>> UpdateShipper(UpdateShipperDto updateShipperDto, string userId);
        Task<Result<bool>> DeleteShipper(Guid shipperId);
    }
}
