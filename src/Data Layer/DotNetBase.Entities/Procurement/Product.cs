using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class Product : BaseEntity, ISoftDeletable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductUnitId { get; set; }
        public int ProductBrandId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsActive { get; set; }
        public decimal CommissionRate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
