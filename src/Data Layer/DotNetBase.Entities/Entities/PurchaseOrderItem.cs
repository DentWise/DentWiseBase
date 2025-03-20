using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class PurchaseOrderItem : BaseEntity
{

    public int? PurchaseOrderId { get; set; }

    public int? SupplierQuotationItemId { get; set; }

    public int? ProductId { get; set; }

    public int OrderedQuantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? LineAmount { get; set; }

    public string? Description { get; set; }

    public virtual Product? Product { get; set; }

    public virtual PurchaseOrder? PurchaseOrder { get; set; }

    public virtual SupplierQuotationItem? SupplierQuotationItem { get; set; }
}
