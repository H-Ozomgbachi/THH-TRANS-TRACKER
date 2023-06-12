namespace ThhTransTracker.Core.Interfaces.IRepositories
{
    public interface ITransactionRepository
    {
        Task<PagedList<Transaction>> GetTransactions(TransactionParam transactionParam);
        Task<Transaction> GetTransaction(Guid transactionId);
        Task<Guid> CreateTransaction(Transaction transaction);
        Task<Transaction> UpdateTransaction(Transaction transaction);
        Task<bool> DeleteTransaction(Guid transactionId);
    }
}
