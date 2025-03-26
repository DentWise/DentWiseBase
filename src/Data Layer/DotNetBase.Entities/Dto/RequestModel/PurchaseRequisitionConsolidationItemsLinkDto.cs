namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreatePurchaseRequisitionConsolidationItemsLink
    {
        public int? RequisitionItemId { get; set; }
        public int? ConsolidatedRequisitionItemId { get; set; }
        public int Quantity { get; set; }
    }
    public class UpdatePurchaseRequisitionConsolidationItemsLink
    {
        public int? RequisitionItemId { get; set; }
        public int? ConsolidatedRequisitionItemId { get; set; }
        public int Quantity { get; set; }
    }
}
