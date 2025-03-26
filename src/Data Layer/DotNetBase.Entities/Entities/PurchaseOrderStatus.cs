using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class PurchaseOrderStatus : BaseEntity, ISoftDeletable
{

    public string StatusName { get; set; } = null!;
    public string? Description { get; set; }
    public bool? IsDefault { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
