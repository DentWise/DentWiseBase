using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class RequestForQuotationItem : BaseEntity, ISoftDeletable
    {
        public int RequestForQuotationId { get; set; }
        public int ConsolidatedRequisitionItemId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
