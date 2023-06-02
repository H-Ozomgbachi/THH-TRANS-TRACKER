namespace ThhTransTracker.Core.Mappers
{
    public class TruckSizeMappers : Profile
    {
        public TruckSizeMappers()
        {
            CreateMap<TruckSizeDto, TruckSize>().ReverseMap();
            CreateMap<CreateTruckSizeDto, TruckSize>().ReverseMap();
            CreateMap<UpdateTruckSizeDto, TruckSize>().ReverseMap();
        }
    }
}
