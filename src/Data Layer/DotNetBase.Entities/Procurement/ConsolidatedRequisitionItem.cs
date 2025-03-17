using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class ConsolidatedRequisitionItem : BaseEntity, ISoftDeletable
    {
        public int PurchaseRequestConsolidationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
