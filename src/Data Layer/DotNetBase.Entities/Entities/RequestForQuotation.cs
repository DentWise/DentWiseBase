using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class RequestForQuotation : BaseEntity, ISoftDeletable
{

    public string Rfqnumber { get; set; } = null!;
    public DateTime Rfqdate { get; set; }
    public int? PurchaseRequestConsolidationId { get; set; }
    public int? SupplierCompanyId { get; set; }
    public int? RfqstatusId { get; set; }
    public string? Description { get; set; }
    public DateTime? SentDate { get; set; }
    public DateTime? ResponseDueDate { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual PurchaseRequestConsolidation? PurchaseRequestConsolidation { get; set; }

    public virtual ICollection<RequestForQuotationItem> RequestForQuotationItems { get; set; } = new List<RequestForQuotationItem>();

    public virtual RequestForQuotationStatus? Rfqstatus { get; set; }

    public virtual Company? SupplierCompany { get; set; }

    public virtual ICollection<SupplierQuotation> SupplierQuotations { get; set; } = new List<SupplierQuotation>();
}
