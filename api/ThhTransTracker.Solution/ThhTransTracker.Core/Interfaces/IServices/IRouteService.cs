namespace ThhTransTracker.Core.Interfaces.IServices
{
    public interface IRouteService
    {
        Task<Result<PagedList<RouteDto>>> GetRoutes(RouteParam routeParam);
        Task<Result<RouteDto>> GetRoute(Guid id);
        Task<Result<Guid>> CreateRoute(CreateRouteDto createRouteDto, string userId);
        Task<Result<RouteDto>> UpdateRoute(UpdateRouteDto updateRouteDto, string userId);
        Task<Result<bool>> DeleteRoute(Guid id);
    }
}