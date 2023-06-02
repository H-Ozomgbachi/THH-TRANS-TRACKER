namespace ThhTransTracker.Core.DTOs
{
    public class TruckSizeDto
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public string Unit { get; set; }
    }

    public class CreateTruckSizeDto
    {
        public int Size { get; set; }
    }

    public class UpdateTruckSizeDto
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
    }
}
