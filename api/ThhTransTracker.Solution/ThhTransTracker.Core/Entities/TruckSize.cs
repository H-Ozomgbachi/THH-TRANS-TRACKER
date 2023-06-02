namespace ThhTransTracker.Core.Entities
{
    public class TruckSize : BaseEntity
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public string Unit { get; set; } = "tons";
    }
}