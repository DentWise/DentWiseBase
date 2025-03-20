using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class RequestForQuotationStatus : BaseEntity
{

    public string StatusName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDefault { get; set; }

    public virtual ICollection<RequestForQuotation> RequestForQuotations { get; set; } = new List<RequestForQuotation>();
}
