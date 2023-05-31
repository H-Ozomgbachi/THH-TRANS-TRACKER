namespace ThhTransTracker.Core.Mappers
{
    public class ShipperMappers : Profile
    {
        public ShipperMappers()
        {
            CreateMap<ShipperDto, Shipper>().ReverseMap();
            CreateMap<CreateShipperDto, Shipper>().ReverseMap();
            CreateMap<UpdateShipperDto, Shipper>().ReverseMap();
        }
    }
}
