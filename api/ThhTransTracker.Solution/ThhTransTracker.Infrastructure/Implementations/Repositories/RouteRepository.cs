namespace ThhTransTracker.Infrastructure.Implementations.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly EfCoreDbContext _dbContext;

        public RouteRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateRoute(Route route)
        {
            var result = _dbContext.Routes.Add(route);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> DeleteRoute(Guid id)
        {
            var route = await GetRoute(id);
            if (route is null)
            {
                throw new NotFoundException($"Route with id: {id} does not exist");
            }
            _dbContext.Remove(route);
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<Route> GetRoute(Guid id)
        {
            return await _dbContext.Routes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Route>> GetRoutes(RouteParam routeParam)
        {
            var source = _dbContext.Routes.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(routeParam.OriginState))
            {
                source = source.Where(x => x.OriginState.ToLower() == routeParam.OriginState.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(routeParam.DestinationState))
            {
                source = source.Where(x => x.DestinationState.ToLower() == routeParam.DestinationState.ToLower());
            }
            
            return await PagedList<Route>
                .ToPagedListAsync(source, routeParam.PageNumber, routeParam.PageSize);
        }

        public async Task<Route> UpdateRoute(Route route)
        {
            var result = _dbContext.Update(route); await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
