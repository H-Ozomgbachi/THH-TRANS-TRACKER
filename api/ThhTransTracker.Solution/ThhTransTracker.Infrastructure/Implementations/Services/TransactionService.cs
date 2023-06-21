namespace ThhTransTracker.Infrastructure.Implementations.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Result<TransactionDto>> CancelRequest(CancelRequestDto cancelRequestDto, string userId)
        {
            return new Result<TransactionDto>
            {
                Content = _mapper.Map<TransactionDto>(await _transactionRepository.CancelRequest(cancelRequestDto, userId)),
            };
        }

        public async Task<Result<TransactionDto>> ConfirmLoading(ConfirmLoadingDto confirmLoadingDto, string userId)
        {
            return new Result<TransactionDto>
            {
                Content = _mapper.Map<TransactionDto>(await _transactionRepository.ConfirmLoading(confirmLoadingDto, userId)),
            };
        }

        public async Task<Result<TransactionDto>> FulfillRequest(FulfillRequestDto fulfillRequestDto, string userId)
        {
            return new Result<TransactionDto>
            {
                Content = _mapper.Map<TransactionDto>(await _transactionRepository.FulfilRequest(fulfillRequestDto, userId)),
            };
        }

        public async Task<Result<TransactionDto>> GetTransaction(Guid transactionId)
        {
            return new Result<TransactionDto>
            {
                Content = _mapper.Map<TransactionDto>(await _transactionRepository.GetTransaction(transactionId)),
            };
        }

        public async Task<Result<PagedList<TransactionDto>>> GetTransactions(TransactionParam transactionParam)
        {
            var result = await _transactionRepository.GetTransactions(transactionParam);

            return new Result<PagedList<TransactionDto>>
            {
                Content = DtoEngine<TransactionDto>.UseListDtoProcessor(result, _mapper)
            };
        }

        public async Task<Result<TransactionDto>> RequestTruck(RequestTruckDto requestTruckDto, string userId)
        {
            var transaction = new Transaction
            {
                CreatedBy = userId
            };
            _mapper.Map(requestTruckDto, transaction);
            return new Result<TransactionDto>
            {
                Content = _mapper.Map<TransactionDto>(await _transactionRepository.CreateTransaction(transaction)),
            };
        }
    }
}
