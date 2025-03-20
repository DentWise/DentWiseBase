using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class Currency : BaseEntity, ISoftDeletable
{
    public string CurrencyCode { get; set; } = null!;
    public string CurrencyName { get; set; } = null!;
    public string? CurrencySymbol { get; set; }
    public bool? IsDefault { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ClinicPayment> ClinicPayments { get; set; } = new List<ClinicPayment>();

    public virtual ICollection<CurrencyRatesHistory> CurrencyRatesHistoryBaseCurrencies { get; set; } = new List<CurrencyRatesHistory>();

    public virtual ICollection<CurrencyRatesHistory> CurrencyRatesHistoryTargetCurrencies { get; set; } = new List<CurrencyRatesHistory>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<SupplierProduct> SupplierProducts { get; set; } = new List<SupplierProduct>();

    public virtual ICollection<SupplierQuotation> SupplierQuotations { get; set; } = new List<SupplierQuotation>();
}
