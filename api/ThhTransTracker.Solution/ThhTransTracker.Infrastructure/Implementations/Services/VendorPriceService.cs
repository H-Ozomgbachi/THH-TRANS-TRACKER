namespace ThhTransTracker.Infrastructure.Implementations.Services
{
    public class VendorPriceService : IVendorPriceService
    {
        private readonly IVendorPriceRepository _vendorPriceRepository;
        private readonly IMapper _mapper;

        public VendorPriceService(IVendorPriceRepository vendorPriceRepository, IMapper mapper)
        {
            _vendorPriceRepository = vendorPriceRepository;
            _mapper = mapper;
        }

        public async Task<Result<string>> CreateVendorPrices(IEnumerable<CreateVendorPriceDto> createVendorPriceDtos, string userId)
        {
            HashSet<VendorPrice> vendorPrices = new();

            foreach (var item in createVendorPriceDtos)
            {
                VendorPrice vendorPrice = new()
                {
                    CreatedBy = userId
                };
                _mapper.Map(item, vendorPrice);
                vendorPrices.Add(vendorPrice);
            }

            return new Result<string>
            {
                Content = await _vendorPriceRepository.CreateVendorPrices(vendorPrices),
            };
        }

        public async Task<Result<bool>> DeleteVendorPrice(Guid vendorPriceId)
        {
            return new Result<bool>
            {
                Content = await _vendorPriceRepository.DeleteVendorPrice(vendorPriceId),
            };
        }

        public async Task<Result<PagedList<VendorPriceDto>>> GetVendorPrices(VendorPriceParam vendorPriceParam, Guid vendorId)
        {
            var result = await _vendorPriceRepository.GetVendorPrices(vendorPriceParam, vendorId);

            return new Result<PagedList<VendorPriceDto>>
            {
                Content = DtoEngine<VendorPriceDto>.UseListDtoProcessor(result, _mapper)
            };
        }

        public async Task<Result<VendorPriceDto>> UpdateVendorPrice(UpdateVendorPriceDto updateVendorPriceDto, string userId)
        {
            VendorPrice vendorPrice = new()
            {
                UpdatedBy = userId,
                DateUpdated = DateTime.UtcNow,
            };
            _mapper.Map(updateVendorPriceDto, vendorPrice);

            return new Result<VendorPriceDto>
            {
                Content = _mapper.Map<VendorPriceDto>(await _vendorPriceRepository.UpdateVendorPrice(vendorPrice))
            };
        }
    }
}
