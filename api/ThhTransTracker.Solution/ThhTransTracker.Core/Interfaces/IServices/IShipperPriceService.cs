namespace ThhTransTracker.Core.Interfaces.IServices
{
    public interface IShipperPriceService
    {
        Task<Result<PagedList<ShipperPriceDto>>> GetShipperPrices(ShipperPriceParam shipperPriceParam, Guid shipperPriceId);
        Task<Result<string>> CreateShipperPrices(IEnumerable<CreateShipperPriceDto> createShipperPriceDtos, string userId);
        Task<Result<ShipperPriceDto>> UpdateShipperPrice(UpdateShipperPriceDto updateShipperPriceDto, string userId);
        Task<Result<bool>> DeleteShipperPrice(Guid shipperPriceId);
    }
}
