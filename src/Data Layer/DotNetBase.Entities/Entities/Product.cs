using DotNetBase.Entities.Abstract;

namespace DotNetBase.EFCore.Entities;

public partial class Product : BaseEntity
{

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public string? ProductCode { get; set; }

    public int? ProductCategoryId { get; set; }

    public int? ProductUnitId { get; set; }

    public int? ProductBrandId { get; set; }

    public decimal? PurchasePrice { get; set; }

    public decimal? SalePrice { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<ConsolidatedRequisitionItem> ConsolidatedRequisitionItems { get; set; } = new List<ConsolidatedRequisitionItem>();

    public virtual Company? ProductBrand { get; set; }

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ICollection<ProductCommission> ProductCommissions { get; set; } = new List<ProductCommission>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ProductUnit? ProductUnit { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual ICollection<RequisitionItem> RequisitionItems { get; set; } = new List<RequisitionItem>();

    public virtual ICollection<SupplierProduct> SupplierProducts { get; set; } = new List<SupplierProduct>();
}
