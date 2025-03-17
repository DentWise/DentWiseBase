﻿using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class ConsolidatedRequisitionItem
{
    public int Id { get; set; }

    public int? PurchaseRequestConsolidationId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual PurchaseRequestConsolidation? PurchaseRequestConsolidation { get; set; }

    public virtual ICollection<PurchaseRequisitionConsolidationItemsLink> PurchaseRequisitionConsolidationItemsLinks { get; set; } = new List<PurchaseRequisitionConsolidationItemsLink>();

    public virtual ICollection<RequestForQuotationItem> RequestForQuotationItems { get; set; } = new List<RequestForQuotationItem>();
}
