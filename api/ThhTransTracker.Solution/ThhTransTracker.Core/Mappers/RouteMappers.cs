namespace ThhTransTracker.Core.Mappers
{
    public class RouteMappers : Profile
    {
        public RouteMappers()
        {
            CreateMap<RouteDto, Route>().ReverseMap();
            CreateMap<CreateRouteDto, Route>().ReverseMap();
            CreateMap<UpdateRouteDto, Route>().ReverseMap();
        }
    }
}
