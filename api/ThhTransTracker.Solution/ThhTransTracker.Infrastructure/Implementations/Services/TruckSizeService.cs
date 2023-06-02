namespace ThhTransTracker.Infrastructure.Implementations.Services
{
    public class TruckSizeService : ITruckSizeService
    {
        private readonly ITruckSizeRepository _truckSizeRepository;
        private readonly IMapper _mapper;

        public TruckSizeService(ITruckSizeRepository truckSizeRepository, IMapper mapper)
        {
            _truckSizeRepository = truckSizeRepository;
            _mapper = mapper;
        }

        public async Task<Result<string>> CreateTruckSizes(IEnumerable<CreateTruckSizeDto> createTruckSizeDtos, string userId)
        {
            HashSet<TruckSize> truckSizes = new();

            foreach (var item in createTruckSizeDtos)
            {
                var truckSize = new TruckSize
                {
                    CreatedBy = userId
                };
                _mapper.Map(item, truckSize);
                truckSizes.Add(truckSize);
            }

            return new Result<string>
            {
                Content = await _truckSizeRepository.CreateTruckSizes(truckSizes)
            };
        }

        public async Task<Result<bool>> DeleteTruckSize(Guid truckSizeId)
        {
            return new Result<bool>
            {
                Content = await _truckSizeRepository.DeleteTruckSizes(truckSizeId)
            };
        }

        public async Task<Result<PagedList<TruckSizeDto>>> GetTruckSizes(TruckSizeParam truckSizeParam)
        {
            var truckSizes = await _truckSizeRepository.GetTruckSizes(truckSizeParam);

            return new Result<PagedList<TruckSizeDto>>
            {
                Content = DtoEngine<TruckSizeDto>.UseListDtoProcessor(truckSizes, _mapper)
            };
        }

        public async Task<Result<TruckSizeDto>> UpdateTruckSize(UpdateTruckSizeDto updateTruckSizeDto, string userId)
        {
            var truckSize = new TruckSize
            {
                UpdatedBy = userId,
                DateUpdated = DateTime.UtcNow,
            };
            _mapper.Map(updateTruckSizeDto, truckSize);
            return new Result<TruckSizeDto>
            {
                Content = _mapper.Map<TruckSizeDto>(await _truckSizeRepository.UpdateTruckSize(truckSize))
            };
        }
    }
}
