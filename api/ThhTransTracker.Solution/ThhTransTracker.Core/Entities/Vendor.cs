namespace ThhTransTracker.Core.Entities
{
    public class Vendor : BaseEntity
    {
        public Guid Id { get; set; }
        public string VendorName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }

        public ICollection<VendorPrice> VendorPrices { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
