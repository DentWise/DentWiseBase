using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class RequestForQuotationItem : BaseEntity, ISoftDeletable
{

    public int? RequestForQuotationId { get; set; }
    public int? ConsolidatedRequisitionItemId { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ConsolidatedRequisitionItem? ConsolidatedRequisitionItem { get; set; }

    public virtual RequestForQuotation? RequestForQuotation { get; set; }

    public virtual ICollection<SupplierQuotationItem> SupplierQuotationItems { get; set; } = new List<SupplierQuotationItem>();
}
