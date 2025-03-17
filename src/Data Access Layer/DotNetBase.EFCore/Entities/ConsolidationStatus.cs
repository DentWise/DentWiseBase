using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class ConsolidationStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDefault { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<PurchaseRequestConsolidation> PurchaseRequestConsolidations { get; set; } = new List<PurchaseRequestConsolidation>();
}
