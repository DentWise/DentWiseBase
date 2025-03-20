using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class PaymentStatus : BaseEntity, ISoftDeletable
{

    public string StatusName { get; set; } = null!;
    public string? Description { get; set; }
    public bool? IsDefault { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<ClinicPayment> ClinicPayments { get; set; } = new List<ClinicPayment>();
}
