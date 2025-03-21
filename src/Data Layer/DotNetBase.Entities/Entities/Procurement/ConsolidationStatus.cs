using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Entities.Procurement;

public partial class ConsolidationStatus : BaseEntity, ISoftDeletable
{

    public string StatusName { get; set; } = null!;
    public string? Description { get; set; }
    public bool? IsDefault { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<PurchaseRequestConsolidation> PurchaseRequestConsolidations { get; set; } = new List<PurchaseRequestConsolidation>();
}
