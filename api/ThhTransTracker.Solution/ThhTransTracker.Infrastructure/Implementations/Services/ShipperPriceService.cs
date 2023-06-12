namespace ThhTransTracker.Infrastructure.Implementations.Services
{
    public class ShipperPriceService : IShipperPriceService
    {
        private readonly IShipperPriceRepository _shipperPriceRepository;
        private readonly IMapper _mapper;

        public ShipperPriceService(IShipperPriceRepository shipperPriceRepository, IMapper mapper)
        {
            _shipperPriceRepository = shipperPriceRepository;
            _mapper = mapper;
        }

        public async Task<Result<string>> CreateShipperPrices(IEnumerable<CreateShipperPriceDto> createShipperPriceDtos, string userId)
        {
            HashSet<ShipperPrice> shipperPrices = new();

            foreach (var item in createShipperPriceDtos)
            {
                ShipperPrice shipperPrice = new()
                {
                    CreatedBy = userId
                };
                _mapper.Map(item, shipperPrice);
                shipperPrices.Add(shipperPrice);
            }
            return new Result<string>
            {
                Content = await _shipperPriceRepository.CreateShipperPrices(shipperPrices)
            };
        }

        public async Task<Result<bool>> DeleteShipperPrice(Guid shipperPriceId)
        {
            return new Result<bool>
            {
                Content = await _shipperPriceRepository.DeleteShipperPrice(shipperPriceId)
            };
        }

        public async Task<Result<PagedList<ShipperPriceDto>>> GetShipperPrices(ShipperPriceParam shipperPriceParam, Guid shipperPriceId)
        {
            var result = await _shipperPriceRepository.GetShipperPrices(shipperPriceParam, shipperPriceId);

            return new Result<PagedList<ShipperPriceDto>>
            {
                Content = DtoEngine<ShipperPriceDto>.UseListDtoProcessor(result, _mapper)
            };
        }

        public async Task<Result<ShipperPriceDto>> UpdateShipperPrice(UpdateShipperPriceDto updateShipperPriceDto, string userId)
        {
            ShipperPrice shipperPrice = new()
            {
                UpdatedBy = userId,
                DateUpdated = DateTime.UtcNow,
            };
            _mapper.Map(updateShipperPriceDto, shipperPrice);
            return new Result<ShipperPriceDto>
            {
                Content = _mapper.Map<ShipperPriceDto>(await _shipperPriceRepository.UpdateShipperPrice(shipperPrice))
            };
        }
    }
}
