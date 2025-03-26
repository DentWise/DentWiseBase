using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class RequisitionStatus : BaseEntity, ISoftDeletable
{

    public string StatusName { get; set; } = null!;
    public string? Description { get; set; }
    public bool? IsDefault { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<PurchaseRequisition> PurchaseRequisitions { get; set; } = new List<PurchaseRequisition>();
}
