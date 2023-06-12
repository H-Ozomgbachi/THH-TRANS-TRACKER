namespace ThhTransTracker.Infrastructure.Implementations.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public VendorService(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<Result<string>> CreateVendors(IEnumerable<CreateVendorDto> createVendorDtos, string userId)
        {
            HashSet<Vendor> vendors = new();

            foreach (var item in createVendorDtos)
            {
                Vendor vendor = new()
                {
                    CreatedBy = userId
                };
                _mapper.Map(item, vendor);
                vendors.Add(vendor);
            }
            return new Result<string>
            {
                Content = await _vendorRepository.CreateVendors(vendors)
            };
        }

        public async Task<Result<bool>> DeleteVendor(Guid vendorId)
        {
            return new Result<bool>
            {
                Content = await _vendorRepository.DeleteVendor(vendorId)
            };
        }

        public async Task<Result<VendorDto>> GetVendor(Guid vendorId)
        {
            return new Result<VendorDto>
            {
                Content = _mapper.Map<VendorDto>(await _vendorRepository.GetVendor(vendorId)),
            };
        }

        public async Task<Result<PagedList<VendorDto>>> GetVendors(VendorParam vendorParam)
        {
            var vendors = await _vendorRepository.GetVendors(vendorParam);

            return new Result<PagedList<VendorDto>>
            {
                Content = DtoEngine<VendorDto>.UseListDtoProcessor(vendors, _mapper)
            };
        }

        public async Task<Result<VendorDto>> UpdateVendor(UpdateVendorDto updateVendorDto, string userId)
        {
            var vendor = new Vendor
            {
                UpdatedBy = userId,
                DateUpdated = DateTime.UtcNow,
            };
            _mapper.Map(updateVendorDto, vendor);
            return new Result<VendorDto>
            {
                Content = _mapper.Map<VendorDto>(await _vendorRepository.UpdateVendor(vendor))
            };
        }
    }
}
