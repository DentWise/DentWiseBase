using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Entities.Procurement;
using System;
using System.Collections.Generic;

namespace DotNetBase.Entities.Entities.Crm;

public partial class CompanyAddress : BaseEntity, ISoftDeletable
{

    public int? CompanyId { get; set; }
    public string? AddressLine { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public bool? IsDefault { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<PurchaseRequisition> PurchaseRequisitions { get; set; } = new List<PurchaseRequisition>();
}
