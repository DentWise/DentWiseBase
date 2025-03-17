using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class RequestForQuotation : BaseEntity, ISoftDeletable
    {
        public string RFQNumber { get; set; }
        public DateTime RFQDate { get; set; }
        public int PurchaseRequestConsolidationId { get; set; }
        public int SupplierCompanyId { get; set; }
        public int RFQStatusId { get; set; }
        public string Description { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime ResponseDueDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
