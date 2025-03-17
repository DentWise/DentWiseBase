using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class SupplierProduct : BaseEntity, ISoftDeletable
    {
        public int ProductId { get; set; }
        public int SupplierCompanyId { get; set; }
        public string SupplierProductCode { get; set; }
        public decimal SupplierPrice { get; set; }
        public int CurrencyId { get; set; }
        public string LeadTime { get; set; }
        public int MOQ { get; set; }
        public decimal DiscountRate { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
