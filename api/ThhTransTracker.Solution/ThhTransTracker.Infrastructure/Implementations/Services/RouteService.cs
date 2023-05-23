namespace ThhTransTracker.Infrastructure.Implementations.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public RouteService(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> CreateRoute(CreateRouteDto createRouteDto, string userId)
        {
            var route = new Route
            {
                CreatedBy = userId,
            };
            _mapper.Map(createRouteDto, route);
            return new Result<Guid>
            {
                Content = await _routeRepository.CreateRoute(route)
            };
        }

        public async Task<Result<bool>> DeleteRoute(Guid id)
        {
            return new Result<bool>
            {
                Content = await _routeRepository.DeleteRoute(id)
            };
        }

        public async Task<Result<RouteDto>> GetRoute(Guid id)
        {
            var route = await _routeRepository.GetRoute(id);
            return new Result<RouteDto>
            {
                Content = _mapper.Map<RouteDto>(route)
            };
        }

        public async Task<Result<PagedList<RouteDto>>> GetRoutes(RouteParam routeParam)
        {
            var routes = await _routeRepository.GetRoutes(routeParam);

            return new Result<PagedList<RouteDto>>
            {
                Content = DtoEngine<RouteDto>.UseListDtoProcessor(routes, _mapper)
            };
        }

        public async Task<Result<RouteDto>> UpdateRoute(UpdateRouteDto updateRouteDto, string userId)
        {
            var route = await _routeRepository.GetRoute(updateRouteDto.Id);

            if (route == null)
            {
                throw new NotFoundException($"Route with id: {updateRouteDto.Id} does not exist");
            }
            _mapper.Map(updateRouteDto, route);
            route.UpdatedBy = userId; route.DateUpdated = DateTime.UtcNow;
            return new Result<RouteDto>
            {
                Content = _mapper.Map<RouteDto>(await _routeRepository.UpdateRoute(route)),
            };
        }
    }
}
