namespace ThhTransTracker.Core.Entities
{
    public class Route : BaseEntity
    {
        public Guid Id { get; set; }
        public string OriginState { get; set; }
        public string OriginCity { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCity { get; set; }
    }
}
