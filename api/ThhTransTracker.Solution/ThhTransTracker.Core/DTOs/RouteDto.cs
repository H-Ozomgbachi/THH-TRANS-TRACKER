namespace ThhTransTracker.Core.DTOs
{
    public class RouteDto
    {
        public Guid Id { get; set; }
        public string OriginState { get; set; }
        public string OriginCity { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCity { get; set; }
    }
    public class CreateRouteDto
    {
        public string OriginState { get; set; }
        public string OriginCity { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCity { get; set; }
    }
    public class UpdateRouteDto
    {
        public Guid Id { get; set; }
        public string OriginState { get; set; }
        public string OriginCity { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCity { get; set; }
    }
}
