namespace ThhTransTracker.Core.Interfaces.IServices
{
    public interface ITransactionService
    {
        Task<Result<PagedList<TransactionDto>>> GetTransactions(TransactionParam transactionParam);
        Task<Result<TransactionDto>> RequestTruck(RequestTruckDto requestTruckDto, string userId);
        Task<Result<TransactionDto>> GetTransaction(Guid transactionId);

        Task<Result<TransactionDto>> FulfillRequest(FulfillRequestDto fulfillRequestDto, string userId);
        Task<Result<TransactionDto>> CancelRequest(CancelRequestDto cancelRequestDto, string userId);
        Task<Result<TransactionDto>> ConfirmLoading(ConfirmLoadingDto confirmLoadingDto, string userId);
    }
}
