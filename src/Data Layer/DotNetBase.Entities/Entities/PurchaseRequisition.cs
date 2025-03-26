using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace DotNetBase.EFCore.Entities;

public partial class PurchaseRequisition : BaseEntity, ISoftDeletable
{
    public string RequisitionNumber { get; set; } = null!;
    public DateTime RequisitionDate { get; set; }
    public int? RequesterUserId { get; set; }
    public int? RequesterCompanyId { get; set; }
    public int? RequisitionStatusId { get; set; }
    public int? DeliveryCompanyAddressId { get; set; }
    public string? Description { get; set; }
    public string? ApprovalNotes { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual CompanyAddress? DeliveryCompanyAddress { get; set; }

    public virtual Company? RequesterCompany { get; set; }

    public virtual User? RequesterUser { get; set; }

    public virtual ICollection<RequisitionItem> RequisitionItems { get; set; } = new List<RequisitionItem>();

    public virtual RequisitionStatus? RequisitionStatus { get; set; }
}
