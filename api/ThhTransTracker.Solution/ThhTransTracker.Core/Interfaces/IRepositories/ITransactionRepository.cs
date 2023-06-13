namespace ThhTransTracker.Core.Interfaces.IRepositories
{
    public interface ITransactionRepository
    {
        Task<PagedList<Transaction>> GetTransactions(TransactionParam transactionParam);
        Task<Transaction> GetTransaction(Guid transactionId);
        Task<Transaction> CreateTransaction(Transaction transaction);
        Task<Transaction> UpdateTransaction(Transaction transaction);
        Task<bool> DeleteTransaction(Guid transactionId);

        Task<Transaction> FulfilRequest(FulfillRequestDto fulfillRequestDto, string userId);
        Task<Transaction> CancelRequest(CancelRequestDto cancelRequestDto, string userId);
        Task<Transaction> ConfirmLoading(ConfirmLoadingDto confirmLoadingDto, string userId);
    }
}
