using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class ClinicPayment : BaseEntity, ISoftDeletable
{
    public int ClinicCompanyId { get; set; }
    public int PurchaseRequestConsolidationId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public int CurrencyId { get; set; }
    public string? PaymentMethod { get; set; }
    public string? ReferenceNumber { get; set; }
    public string? Notes { get; set; }
    public int? PrePaymentStatusId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt {  get; set; }

    public virtual Company ClinicCompany { get; set; } = null!;

    public virtual Currency Currency { get; set; } = null!;

    public virtual PaymentStatus? PrePaymentStatus { get; set; }

    public virtual PurchaseRequestConsolidation PurchaseRequestConsolidation { get; set; } = null!;
}
