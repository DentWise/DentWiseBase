using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class SupplierQuotationItem : BaseEntity, ISoftDeletable
    {
        public int SupplierQuotationId { get; set; }
        public int RequestForQuotationItemId { get; set; }
        public string SupplierProductCode { get; set; }
        public int OfferedQuantity { get; set; }
        public decimal OfferedPrice { get; set; }
        public string LeadTime { get; set; }
        public string Note { get; set; }
        public bool IsOffered { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
