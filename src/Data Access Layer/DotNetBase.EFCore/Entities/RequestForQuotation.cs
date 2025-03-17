using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class RequestForQuotation
{
    public int Id { get; set; }

    public string Rfqnumber { get; set; } = null!;

    public DateTime Rfqdate { get; set; }

    public int? PurchaseRequestConsolidationId { get; set; }

    public int? SupplierCompanyId { get; set; }

    public int? RfqstatusId { get; set; }

    public string? Description { get; set; }

    public DateTime? SentDate { get; set; }

    public DateTime? ResponseDueDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual PurchaseRequestConsolidation? PurchaseRequestConsolidation { get; set; }

    public virtual ICollection<RequestForQuotationItem> RequestForQuotationItems { get; set; } = new List<RequestForQuotationItem>();

    public virtual RequestForQuotationStatus? Rfqstatus { get; set; }

    public virtual Company? SupplierCompany { get; set; }

    public virtual ICollection<SupplierQuotation> SupplierQuotations { get; set; } = new List<SupplierQuotation>();
}
