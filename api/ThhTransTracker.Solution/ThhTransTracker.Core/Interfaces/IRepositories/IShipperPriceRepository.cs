namespace ThhTransTracker.Core.Interfaces.IRepositories
{
    public interface IShipperPriceRepository
    {
        Task<PagedList<ShipperPrice>> GetShipperPrices(ShipperPriceParam shipperPriceParam, Guid shipperId);
        Task<string> CreateShipperPrices(IEnumerable<ShipperPrice> shipperPrices);
        Task<ShipperPrice> UpdateShipperPrice(ShipperPrice shipperPrice);
        Task<bool> DeleteShipperPrice(Guid shipperPriceId);
    }
}