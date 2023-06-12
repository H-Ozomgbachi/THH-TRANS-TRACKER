namespace ThhTransTracker.Core.DTOs
{
    public class ShipperPriceDto
    {
        public Guid Id { get; set; }
        public string Origin { get; set; }
        public string DestinationCity { get; set; }
        public int TruckSize { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
        public Guid ShipperId { get; set; }
    }
    public class CreateShipperPriceDto
    {
        public string Origin { get; set; }
        public string DestinationCity { get; set; }
        public int TruckSize { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
        public Guid ShipperId { get; set; }
    }
    public class UpdateShipperPriceDto
    {
        public Guid Id { get; set; }
        public string Origin { get; set; }
        public string DestinationCity { get; set; }
        public int TruckSize { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
