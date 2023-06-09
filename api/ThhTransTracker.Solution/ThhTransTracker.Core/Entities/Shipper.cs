﻿namespace ThhTransTracker.Core.Entities
{
    public class Shipper : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public ICollection<ShipperPrice> ShipperPrices { get; set; }
    }
}
