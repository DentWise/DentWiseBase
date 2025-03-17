using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class PurchaseOrderItem : BaseEntity, ISoftDeletable
    {
        public int PurchaseOrderId { get; set; }
        public int SupplierQuotationItemId { get; set; }
        public int ProductId { get; set; }
        public int OrderedQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineAmount { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
