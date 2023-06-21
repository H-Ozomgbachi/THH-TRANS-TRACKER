namespace ThhTransTracker.Core.QueryParams
{
    public class TransactionParam : BaseParam
    {
        public bool IsFulfilled { get; set; } = false;
        public bool IsLoaded { get; set; } = false;
    }
}
