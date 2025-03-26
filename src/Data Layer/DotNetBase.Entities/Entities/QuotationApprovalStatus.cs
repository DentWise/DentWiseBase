using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class QuotationApprovalStatus : BaseEntity, ISoftDeletable
{

    public string StatusName { get; set; } = null!;
    public string? Description { get; set; }
    public bool? IsDefault { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<SupplierQuotation> SupplierQuotations { get; set; } = new List<SupplierQuotation>();
}
