using ThhTransTracker.Core.Enums;

namespace ThhTransTracker.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid Id { get; set; }
        public string ShipperName { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public int TruckSize { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsFulfilled { get; set; } = false;
        public CarrierClass CarrierClass { get; set; }
        public string VendorName { get; set; }
        public string InvestorName { get; set; }
        public string TruckNumber { get; set; }
        public DateTime FulfilmentDate { get; set; } = DateTime.MinValue;
        public bool IsAwaitingLoading { get; set; } = false;
        public bool IsCancelled { get; set; } = false;
        public string CancelledBy { get; set; }
        public string CancellationReason { get; set; }
        public bool IsLoaded { get; set; } = false;
        public DateTime LoadingDate { get; set; }
        public string WaybillImage { get; set; }
        public WaybillDetail WaybillDetail { get; set; }
        public bool IsMobilized { get; set; } = false;
        public bool IsInTransit { get; set; } = false;
        public bool IsThereEmergency { get; set; } = false;
        public string EmergencyInfo { get; set; }
        public bool SentNotification { get; set; } = false;
        public bool IsEmergencyResolved { get; set; } = false;
        public string ResolutionInfo { get; set; }
        public DateTime DateOffloaded { get; set; }
        public bool IsOffloaded { get; set; } = false;
        public bool PendingBalance { get; set; } = false;
        public bool PendingWaybill { get; set; } = false;
        public bool IsArchived { get; set; } = false;
    }
}
