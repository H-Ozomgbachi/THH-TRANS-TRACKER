namespace ThhTransTracker.Core.Interfaces.IRepositories
{
    public interface IShipperRepository
    {
        Task<PagedList<Shipper>> GetShippers(ShipperParam shipperParam);
        Task<Shipper> GetShipper(Guid shipperId);
        Task<Guid> CreateShipper(Shipper shipper);
        Task<Shipper> UpdateShipper(Shipper shipper);
        Task<bool> DeleteShipper(Guid shipperId);
    }
}
