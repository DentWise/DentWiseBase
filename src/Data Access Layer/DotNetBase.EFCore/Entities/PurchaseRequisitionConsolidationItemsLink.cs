using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class PurchaseRequisitionConsolidationItemsLink
{
    public int Id { get; set; }

    public int? RequisitionItemId { get; set; }

    public int? ConsolidatedRequisitionItemId { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ConsolidatedRequisitionItem? ConsolidatedRequisitionItem { get; set; }

    public virtual RequisitionItem? RequisitionItem { get; set; }
}
