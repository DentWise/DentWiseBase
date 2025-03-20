namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateConsolidatedRequisitionItem
    {
        public int? PurchaseRequestConsolidationId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateConsolidatedRequisitionItem
    {
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
