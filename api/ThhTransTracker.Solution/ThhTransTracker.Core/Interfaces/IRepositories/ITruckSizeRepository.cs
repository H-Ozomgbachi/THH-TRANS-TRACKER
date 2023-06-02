namespace ThhTransTracker.Core.Interfaces.IRepositories
{
    public interface ITruckSizeRepository
    {
        Task<PagedList<TruckSize>> GetTruckSizes(TruckSizeParam truckSizeParam);
        Task<string> CreateTruckSizes(IEnumerable<TruckSize> truckSizes);
        Task<TruckSize> UpdateTruckSize(TruckSize truckSize);
        Task<bool> DeleteTruckSizes(Guid truckSizeId);
    }
}
