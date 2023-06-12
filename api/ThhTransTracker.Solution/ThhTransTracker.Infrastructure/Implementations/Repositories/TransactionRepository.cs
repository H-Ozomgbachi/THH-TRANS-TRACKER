namespace ThhTransTracker.Infrastructure.Implementations.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly EfCoreDbContext _dbContext;

        public TransactionRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateTransaction(Transaction transaction)
        {
            var result = _dbContext.Transactions.Add(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> DeleteTransaction(Guid transactionId)
        {
            var transaction = await _dbContext.Transactions.Where(x => x.Id == transactionId).FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new NotFoundException($"Transaction with id : {transactionId} not found!");
            }
            _dbContext.Transactions.Remove(transaction);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Transaction> GetTransaction(Guid transactionId)
        {
            var transaction = await _dbContext.Transactions
                .AsNoTracking()
                .Where(x => x.Id == transactionId)
                .Include(x => x.WaybillDetail)
                .FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new NotFoundException($"Transaction with id : {transactionId} not found!");
            }
            return transaction;
        }

        public async Task<PagedList<Transaction>> GetTransactions(TransactionParam transactionParam)
        {
            var source = _dbContext.Transactions.AsNoTracking();

            return await PagedList<Transaction>
                .ToPagedListAsync(source, transactionParam.PageNumber, transactionParam.PageSize);
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            var existingTransaction = await _dbContext.Transactions.Where(x => x.Id == transaction.Id).FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new NotFoundException($"Transaction with id : {transaction.Id} not found!");
            }
            var result = _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
