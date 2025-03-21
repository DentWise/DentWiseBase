using DotNetBase.Entities.Abstract;
using System.Reflection.Metadata.Ecma335;

namespace DotNetBase.Entities.Entities.Procurement;

public partial class ConsolidatedRequisitionItem : BaseEntity, ISoftDeletable
{

    public int? PurchaseRequestConsolidationId { get; set; }
    public int? ProductId { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual PurchaseRequestConsolidation? PurchaseRequestConsolidation { get; set; }

    public virtual ICollection<PurchaseRequisitionConsolidationItemsLink> PurchaseRequisitionConsolidationItemsLinks { get; set; } = new List<PurchaseRequisitionConsolidationItemsLink>();

    public virtual ICollection<RequestForQuotationItem> RequestForQuotationItems { get; set; } = new List<RequestForQuotationItem>();
}
