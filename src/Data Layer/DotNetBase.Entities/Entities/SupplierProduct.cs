using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class SupplierProduct : BaseEntity
{

    public int? ProductId { get; set; }

    public int? SupplierCompanyId { get; set; }

    public string? SupplierProductCode { get; set; }

    public decimal? SupplierPrice { get; set; }

    public int? CurrencyId { get; set; }

    public string? LeadTime { get; set; }

    public int? Moq { get; set; }

    public string? DiscountRates { get; set; }

    public string? Notes { get; set; }

    public bool? IsActive { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Company? SupplierCompany { get; set; }
}
