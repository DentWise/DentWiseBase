using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class PurchaseOrder : BaseEntity
{

    public string PurchaseOrderNumber { get; set; } = null!;

    public DateTime PurchaseOrderDate { get; set; }

    public int? SupplierQuotationId { get; set; }

    public int? RequestForQuotationId { get; set; }

    public int? SupplierCompanyId { get; set; }

    public int? PurchaseOrderStatusId { get; set; }

    public string? Description { get; set; }

    public decimal? OrderAmount { get; set; }

    public int? CurrencyId { get; set; }

    public string? PaymentTerms { get; set; }

    public string? DeliveryTerms { get; set; }

    public DateTime? ExpectedDeliveryDate { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual PurchaseOrderStatus? PurchaseOrderStatus { get; set; }

    public virtual RequestForQuotation? RequestForQuotation { get; set; }

    public virtual ICollection<ShipmentTracking> ShipmentTrackings { get; set; } = new List<ShipmentTracking>();

    public virtual Company? SupplierCompany { get; set; }

    public virtual SupplierQuotation? SupplierQuotation { get; set; }
}
