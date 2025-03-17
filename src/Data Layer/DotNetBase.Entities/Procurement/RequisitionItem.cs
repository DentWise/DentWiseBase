using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class RequisitionItem : BaseEntity, ISoftDeletable
    {
        public int PurchaseRequisitionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
