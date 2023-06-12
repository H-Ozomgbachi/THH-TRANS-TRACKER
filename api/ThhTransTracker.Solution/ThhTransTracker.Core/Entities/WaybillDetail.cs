namespace ThhTransTracker.Core.Entities
{
    public class WaybillDetail
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string LoadingPoint { get; set; }
        public string OrderNumber { get; set; }
        public string DeliveryNumber { get; set; }

        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}
