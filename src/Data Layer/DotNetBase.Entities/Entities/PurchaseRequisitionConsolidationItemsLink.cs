using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class PurchaseRequisitionConsolidationItemsLink : BaseEntity, ISoftDeletable
{

    public int? RequisitionItemId { get; set; }
    public int? ConsolidatedRequisitionItemId { get; set; }
    public int Quantity { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ConsolidatedRequisitionItem? ConsolidatedRequisitionItem { get; set; }

    public virtual RequisitionItem? RequisitionItem { get; set; }
}
