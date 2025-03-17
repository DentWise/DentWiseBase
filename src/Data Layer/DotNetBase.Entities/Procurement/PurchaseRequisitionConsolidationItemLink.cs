using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class PurchaseRequisitionConsolidationItemLink : BaseEntity, ISoftDeletable
    {
        public int RequisitionItemId { get; set; }
        public int ConsolidatedRequisitionItemId { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
