﻿using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class SupplierQuotationItem : BaseEntity, ISoftDeletable
{
    public int? SupplierQuotationId { get; set; }
    public int? RequestForQuotationItemId { get; set; }
    public string? SupplierProductCode { get; set; }
    public int OfferedQuantity { get; set; }
    public decimal? OfferedPrice { get; set; }
    public string? LeadTime { get; set; }
    public string? Notes { get; set; }
    public bool? IsOffered { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual RequestForQuotationItem? RequestForQuotationItem { get; set; }

    public virtual SupplierQuotation? SupplierQuotation { get; set; }
}
