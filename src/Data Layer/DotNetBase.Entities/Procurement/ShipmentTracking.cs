using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Enum;

namespace DotNetBase.Entities.Procurement
{
    public class ShipmentTracking : BaseEntity, ISoftDeletable
    {
        public int PurchaseOrderId { get; set; }
        public string TrackingNumber { get; set; }
        public CarrierCompanyEnum CarrierCompany { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string TrackingUrl { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
