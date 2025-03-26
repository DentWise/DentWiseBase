namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateShipmentTracking
    {
        public int PurchaseOrderId { get; set; }
        public string TrackingNumber { get; set; } = null!;
        public int? CarrierCompanyId { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public string? TrackingUrl { get; set; }
        public string? Notes { get; set; }
    }
}
