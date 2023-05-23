namespace ThhTransTracker.Core.Interfaces.IRepositories
{
    public interface IRouteRepository
    {
        Task<PagedList<Route>> GetRoutes(RouteParam routeParam);
        Task<Route> GetRoute(Guid id);
        Task<Guid> CreateRoute(Route route);
        Task<Route> UpdateRoute(Route route);
        Task<bool> DeleteRoute(Guid id);
    }
}
