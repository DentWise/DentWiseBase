using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class PurchaseRequestConsolidation : BaseEntity, ISoftDeletable
    {
        public string ConsolidationNumber { get; set; }
        public DateTime ConsolidationDate { get; set; }
        public string Description { get; set; }
        public int ConsolidationStatusId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
