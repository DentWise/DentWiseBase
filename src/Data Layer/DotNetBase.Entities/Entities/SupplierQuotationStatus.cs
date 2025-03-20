using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class SupplierQuotationStatus : BaseEntity
{

    public string StatusName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDefault { get; set; }

    public virtual ICollection<SupplierQuotation> SupplierQuotations { get; set; } = new List<SupplierQuotation>();
}
