namespace ThhTransTracker.Infrastructure.Implementations.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly EfCoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUtilityRepository _utilityRepository;

        public TransactionRepository(EfCoreDbContext dbContext, IMapper mapper, IUtilityRepository utilityRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _utilityRepository = utilityRepository;
        }

        public async Task<Transaction> CancelRequest(CancelRequestDto cancelRequestDto, string userId)
        {
            var transaction = await GetTransaction(cancelRequestDto.Id);

            _mapper.Map(cancelRequestDto, transaction);

            transaction.CancelledBy = userId;transaction.UpdatedBy = userId; transaction.DateUpdated = DateTime.UtcNow;
            transaction.IsCancelled = true;

            var result = _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transaction> ConfirmLoading(ConfirmLoadingDto confirmLoadingDto, string userId)
        {
            var transaction = await GetTransaction(confirmLoadingDto.Id);

            _mapper.Map(confirmLoadingDto, transaction);

            transaction.WaybillImage = await _utilityRepository.UploadFile(confirmLoadingDto.WaybillFile);
            transaction.WaybillDetail = _mapper.Map<WaybillDetail>(confirmLoadingDto.WaybillDetail);

            transaction.IsLoaded = true; transaction.UpdatedBy = userId; transaction.DateUpdated = DateTime.UtcNow;
            transaction.IsAwaitingLoading = false;

            var result = _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
            result.Entity.WaybillDetail.Transaction = null;
            return result.Entity;
        }

        public async Task<Transaction> ConfirmOffloading(ConfirmOffloadingDto confirmOffloadingDto, string userId)
        {
            var transaction = await GetTransaction(confirmOffloadingDto.Id);

            _mapper.Map(confirmOffloadingDto, transaction);

            transaction.IsAwaitingOffload = false; transaction.UpdatedBy = userId; transaction.DateUpdated = DateTime.UtcNow;

            var result = _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            int countForTheMonth = await _dbContext.Transactions.CountAsync(x => x.DateCreated.Month == DateTime.UtcNow.Month && x.DateCreated.Year == DateTime.UtcNow.Year) + 1;

            transaction.UniqueTransactionCode = $"THH{DateTime.UtcNow.Year}{DateTime.UtcNow.Month.ToString().PadLeft(2, '0')}{countForTheMonth.ToString().PadLeft(4, '0')}";

            var result = _dbContext.Transactions.Add(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
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

        public async Task<Transaction> EndTrip(Guid transactionId, string userId)
        {
            var transaction = await GetTransaction(transactionId);

            transaction.IsInTransit = false; transaction.IsAwaitingOffload = true; transaction.UpdatedBy = userId; transaction.DateUpdated = DateTime.UtcNow;

            var result = _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transaction> FulfilRequest(FulfillRequestDto fulfillRequestDto, string userId)
        {
            var transaction = await GetTransaction(fulfillRequestDto.Id);

            _mapper.Map(fulfillRequestDto, transaction);

            transaction.UpdatedBy = userId; transaction.DateUpdated = DateTime.UtcNow; transaction.IsFulfilled = true;
            transaction.IsAwaitingLoading = true;

            var result = _dbContext.Update(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
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

            source = source.Where(x => x.IsFulfilled == transactionParam.IsFulfilled);
            source = source.Where(x => x.IsLoaded == transactionParam.IsLoaded);

            return await PagedList<Transaction>
                .ToPagedListAsync(source, transactionParam.PageNumber, transactionParam.PageSize);
        }

        public async Task<Transaction> Mobilize(MobilizeDto mobilizeDto, string userId)
        {
            var transaction = await GetTransaction(mobilizeDto.Id);

            _mapper.Map(mobilizeDto, transaction);

            transaction.UpdatedBy = userId; transaction.DateUpdated = DateTime.UtcNow; transaction.IsInTransit = true;
            transaction.PendingBalance = transaction.Balance > 0; transaction.IsMobilized = true;

            var result = _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transaction> RaiseEmergency(RaiseEmergencyDto raiseEmergencyDto, string userId)
        {
            var transaction = await GetTransaction(raiseEmergencyDto.Id);

            _mapper.Map(raiseEmergencyDto, transaction);
            transaction.IsThereEmergency = true; transaction.UpdatedBy = userId; transaction.DateUpdated = DateTime.UtcNow;

            var result = _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transaction> ResolveEmergency(ResolveEmergencyDto resolveEmergencyDto, string userId)
        {
            var transaction = await GetTransaction(resolveEmergencyDto.Id);

            _mapper.Map(resolveEmergencyDto, transaction);
            transaction.IsEmergencyResolved = true; transaction.UpdatedBy = userId; transaction.DateUpdated = DateTime.UtcNow;

            var result = _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            var existingTransaction = await _dbContext.Transactions
                .Where(x => x.Id == transaction.Id).FirstOrDefaultAsync();

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
