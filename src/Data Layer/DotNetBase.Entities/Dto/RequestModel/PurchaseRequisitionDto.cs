namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreatePurchaseRequisition
    {
        public string RequisitionNumber { get; set; } = null!;
        public DateTime RequisitionDate { get; set; }
        public int? RequesterUserId { get; set; }
        public int? RequesterCompanyId { get; set; }
        public int? RequisitionStatusId { get; set; }
        public int? DeliveryCompanyAddressId { get; set; }
        public string? Description { get; set; }
        public string? ApprovalNotes { get; set; }
    }

    public class UpdatePurchaseRequisition
    {
        public DateTime RequisitionDate { get; set; }
        public int? RequisitionStatusId { get; set; }
        public string? Description { get; set; }
        public string? ApprovalNotes { get; set; }
    }
}
