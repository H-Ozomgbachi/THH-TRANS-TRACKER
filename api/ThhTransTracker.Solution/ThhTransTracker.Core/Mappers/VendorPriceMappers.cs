namespace ThhTransTracker.Core.Mappers
{
    public class VendorPriceMappers : Profile
    {
        public VendorPriceMappers()
        {
            CreateMap<CreateVendorPriceDto, VendorPrice>().ReverseMap();
            CreateMap<UpdateVendorPriceDto, VendorPrice>().ReverseMap();
            CreateMap<VendorPriceDto, VendorPrice>().ReverseMap();
        }
    }
}
