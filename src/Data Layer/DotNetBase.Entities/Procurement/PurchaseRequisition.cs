using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class PurchaseRequisition : BaseEntity, ISoftDeletable
    {
        public string RequisitionNumber { get; set; }
        public DateTime RequisitionDate { get; set; }
        public int RequesterId { get; set; }
        public int RequesterCompanyId { get; set; }
        public int RequisitionStatusId { get; set; }
        public int DeliveryCompanyAddressId { get; set; }
        public string Description { get; set; }
        public string ApprovalNote { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
