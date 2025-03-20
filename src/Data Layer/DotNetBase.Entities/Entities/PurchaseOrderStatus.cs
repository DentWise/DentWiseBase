using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class PurchaseOrderStatus : BaseEntity
{

    public string StatusName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDefault { get; set; }

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
