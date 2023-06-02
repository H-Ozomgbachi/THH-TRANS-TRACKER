namespace ThhTransTracker.Core.Interfaces.IServices
{
    public interface ITruckSizeService
    {
        Task<Result<PagedList<TruckSizeDto>>> GetTruckSizes(TruckSizeParam truckSizeParam);
        Task<Result<string>> CreateTruckSizes(IEnumerable<CreateTruckSizeDto> createTruckSizeDtos, string userId);
        Task<Result<TruckSizeDto>> UpdateTruckSize(UpdateTruckSizeDto updateTruckSizeDto, string userId);
        Task<Result<bool>> DeleteTruckSize(Guid truckSizeId);
    }
}