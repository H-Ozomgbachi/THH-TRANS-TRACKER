namespace ThhTransTracker.Core.DTOs
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public string ShipperName { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public int TruckSize { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsFulfilled { get; set; }
        public CarrierClass CarrierClass { get; set; }
        public string TruckNumber { get; set; }
        public DateTime FulfilmentDate { get; set; }
        public bool IsAwaitingLoading { get; set; }
        public bool IsCancelled { get; set; }
        public string CancelledBy { get; set; }
        public string CancellationReason { get; set; }
        public bool IsLoaded { get; set; } = false;
        public DateTime LoadingDate { get; set; }
        public string WaybillImage { get; set; }
        public WaybillDetailDto WaybillDetail { get; set; }
        public bool IsMobilized { get; set; }
        public bool IsInTransit { get; set; }
        public bool IsThereEmergency { get; set; }
        public string EmergencyInfo { get; set; }
        public bool SentNotification { get; set; }
        public bool IsEmergencyResolved { get; set; }
        public string ResolutionInfo { get; set; }
        public DateTime DateOffloaded { get; set; }
        public bool IsOffloaded { get; set; }
        public bool PendingBalance { get; set; }
        public bool PendingWaybill { get; set; }
        public bool IsArchived { get; set; }
        public string UniqueTransactionCode { get; set; }
    }
    public class RequestTruckDto
    {
        public string ShipperName { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public int TruckSize { get; set; }
        public DateTime RequestDate { get; set; }
    }
    public class FulfillRequestDto
    {
        public Guid Id { get; set; }
        public CarrierClass CarrierClass { get; set; }
        public string VendorName { get; set; }
        public string InvestorName { get; set; }
        public string TruckNumber { get; set; }
        public DateTime FulfilmentDate { get; set; }
    }

    public class CancelRequestDto
    {
        public Guid Id { get; set; }
        public string CancellationReason { get; set; }
    }
    public class ConfirmLoadingDto
    {
        public Guid Id { get; set; }
        public DateTime LoadingDate { get; set; }
        public IFormFile WaybillFile { get; set; }
        public CreateWaybillDetailDto WaybillDetail { get; set; }
    }
}