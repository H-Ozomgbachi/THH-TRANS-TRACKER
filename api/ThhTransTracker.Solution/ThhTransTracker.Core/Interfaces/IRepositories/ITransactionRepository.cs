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
        Task<Transaction> Mobilize(MobilizeDto mobilizeDto, string userId);
        Task<Transaction> EndTrip(Guid transactionId, string userId);
        Task<Transaction> RaiseEmergency(RaiseEmergencyDto raiseEmergencyDto, string userId);
        Task<Transaction> ResolveEmergency(ResolveEmergencyDto resolveEmergencyDto, string userId);
        Task<Transaction> ConfirmOffloading(ConfirmOffloadingDto confirmOffloadingDto, string userId);
    }
}
