using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Entities.Procurement;

public partial class RequestForQuotationItem : BaseEntity
{

    public int? RequestForQuotationId { get; set; }

    public int? ConsolidatedRequisitionItemId { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public virtual ConsolidatedRequisitionItem? ConsolidatedRequisitionItem { get; set; }

    public virtual RequestForQuotation? RequestForQuotation { get; set; }

    public virtual ICollection<SupplierQuotationItem> SupplierQuotationItems { get; set; } = new List<SupplierQuotationItem>();
}
