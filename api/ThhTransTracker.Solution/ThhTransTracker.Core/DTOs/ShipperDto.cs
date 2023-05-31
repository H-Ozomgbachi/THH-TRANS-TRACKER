namespace ThhTransTracker.Core.DTOs
{
    public class ShipperDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }

    public class CreateShipperDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
    public class UpdateShipperDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
