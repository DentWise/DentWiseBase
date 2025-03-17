using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class RequestForQuotationItem
{
    public int Id { get; set; }

    public int? RequestForQuotationId { get; set; }

    public int? ConsolidatedRequisitionItemId { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ConsolidatedRequisitionItem? ConsolidatedRequisitionItem { get; set; }

    public virtual RequestForQuotation? RequestForQuotation { get; set; }

    public virtual ICollection<SupplierQuotationItem> SupplierQuotationItems { get; set; } = new List<SupplierQuotationItem>();
}
