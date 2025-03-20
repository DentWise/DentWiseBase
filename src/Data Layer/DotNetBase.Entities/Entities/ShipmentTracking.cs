using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class ShipmentTracking : BaseEntity
{

    public int PurchaseOrderId { get; set; }

    public string TrackingNumber { get; set; } = null!;

    public int? CarrierCompanyId { get; set; }

    public DateTime? ShipmentDate { get; set; }

    public DateTime? EstimatedDeliveryDate { get; set; }

    public string? TrackingUrl { get; set; }

    public string? Notes { get; set; }

    public virtual Company? CarrierCompany { get; set; }

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
