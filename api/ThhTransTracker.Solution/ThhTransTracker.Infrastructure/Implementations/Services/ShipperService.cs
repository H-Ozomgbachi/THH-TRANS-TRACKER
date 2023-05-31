namespace ThhTransTracker.Infrastructure.Implementations.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly IMapper _mapper;

        public ShipperService(IShipperRepository shipperRepository, IMapper mapper)
        {
            _shipperRepository = shipperRepository;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> CreateShipper(CreateShipperDto createShipperDto, string userId)
        {
            var shipper = new Shipper()
            {
                CreatedBy = userId
            };
            _mapper.Map(createShipperDto, shipper);
            return new Result<Guid>
            {
                Content = await _shipperRepository.CreateShipper(shipper)
            };
        }

        public async Task<Result<bool>> DeleteShipper(Guid shipperId)
        {
            return new Result<bool>
            {
                Content = await _shipperRepository.DeleteShipper(shipperId)
            };
        }

        public async Task<Result<ShipperDto>> GetShipper(Guid shipperId)
        {
            var shipper = await _shipperRepository.GetShipper(shipperId);
            return new Result<ShipperDto>
            {
                Content = _mapper.Map<ShipperDto>(shipper)
            };
        }

        public async Task<Result<PagedList<ShipperDto>>> GetShippers(ShipperParam shipperParam)
        {
            var shippers = await _shipperRepository.GetShippers(shipperParam);

            return new Result<PagedList<ShipperDto>>
            {
                Content = DtoEngine<ShipperDto>.UseListDtoProcessor(shippers, _mapper)
            };
        }

        public async Task<Result<ShipperDto>> UpdateShipper(UpdateShipperDto updateShipperDto, string userId)
        {
            var shipper = new Shipper
            {
                UpdatedBy = userId,
                DateUpdated = DateTime.UtcNow,
            };
            _mapper.Map(updateShipperDto, shipper);
            return new Result<ShipperDto>
            {
                Content = _mapper.Map<ShipperDto>(await _shipperRepository.UpdateShipper(shipper))
            };
        }
    }
}
