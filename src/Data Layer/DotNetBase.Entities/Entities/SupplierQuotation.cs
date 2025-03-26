using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class SupplierQuotation : BaseEntity, ISoftDeletable
{
    public string QuotationNumber { get; set; } = null!;
    public DateTime QuotationDate { get; set; }
    public int? RequestForQuotationId { get; set; }
    public int? SupplierCompanyId { get; set; }
    public int? QuotationStatusId { get; set; }
    public DateTime? SubmissionDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? PaymentTerms { get; set; }
    public string? DeliveryTerms { get; set; }
    public string? Notes { get; set; }
    public int? CurrencyId { get; set; }
    public int? QuotationApprovalStatusId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual QuotationApprovalStatus? QuotationApprovalStatus { get; set; }

    public virtual SupplierQuotationStatus? QuotationStatus { get; set; }

    public virtual RequestForQuotation? RequestForQuotation { get; set; }

    public virtual Company? SupplierCompany { get; set; }

    public virtual ICollection<SupplierQuotationItem> SupplierQuotationItems { get; set; } = new List<SupplierQuotationItem>();
}
