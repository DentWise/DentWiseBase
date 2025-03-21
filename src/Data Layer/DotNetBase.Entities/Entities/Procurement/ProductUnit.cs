using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Entities.Procurement;

public partial class ProductUnit : BaseEntity
{
    public string UnitName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDefault { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
