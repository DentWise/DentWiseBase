using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class PurchaseRequisitionConsolidationItemsLink : BaseEntity
{

    public int? RequisitionItemId { get; set; }

    public int? ConsolidatedRequisitionItemId { get; set; }

    public int Quantity { get; set; }

    public virtual ConsolidatedRequisitionItem? ConsolidatedRequisitionItem { get; set; }

    public virtual RequisitionItem? RequisitionItem { get; set; }
}
