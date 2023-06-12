namespace ThhTransTracker.Core.Mappers
{
    public class ShipperPriceMappers : Profile
    {
        public ShipperPriceMappers()
        {
            CreateMap<CreateShipperPriceDto, ShipperPrice>().ReverseMap();
            CreateMap<UpdateShipperPriceDto, ShipperPrice>().ReverseMap();
            CreateMap<ShipperPriceDto, ShipperPrice>().ReverseMap();
        }
    }
}
