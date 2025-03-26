using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class ProductUnit : BaseEntity, ISoftDeletable
{
    public string UnitName { get; set; } = null!;
    public string? Description { get; set; }
    public bool? IsDefault { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
