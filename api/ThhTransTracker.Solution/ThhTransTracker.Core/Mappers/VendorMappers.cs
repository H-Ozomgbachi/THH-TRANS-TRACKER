namespace ThhTransTracker.Core.Mappers
{
    public class VendorMappers : Profile
    {
        public VendorMappers()
        {
            CreateMap<CreateVendorDto, Vendor>().ReverseMap();
            CreateMap<UpdateVendorDto, Vendor>().ReverseMap();
            CreateMap<VendorDto, Vendor>().ReverseMap();
        }
    }
}
