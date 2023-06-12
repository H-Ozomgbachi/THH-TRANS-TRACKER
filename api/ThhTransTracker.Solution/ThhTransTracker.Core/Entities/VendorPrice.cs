namespace ThhTransTracker.Core.Entities
{
    public class VendorPrice : BaseEntity
    {
        public Guid Id { get; set; }
        public string Origin { get; set; }
        public string DestinationCity { get; set; }
        public int TruckSize { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }

        public Guid VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
