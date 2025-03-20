using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class RequisitionItem : BaseEntity
{

    public int? PurchaseRequisitionId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public virtual Product? Product { get; set; }

    public virtual PurchaseRequisition? PurchaseRequisition { get; set; }

    public virtual ICollection<PurchaseRequisitionConsolidationItemsLink> PurchaseRequisitionConsolidationItemsLinks { get; set; } = new List<PurchaseRequisitionConsolidationItemsLink>();
}
