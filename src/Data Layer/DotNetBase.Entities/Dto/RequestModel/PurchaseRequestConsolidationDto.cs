namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreatePurchaseRequestConsolidation
    {
        public string ConsolidationNumber { get; set; } = null!;
        public DateTime ConsolidationDate { get; set; }
        public string? Description { get; set; }
        public int? ConsolidationStatusId { get; set; }
    }
    public class UpdatePurchaseRequestConsolidation
    {
        public string ConsolidationNumber { get; set; } = null!;
        public DateTime ConsolidationDate { get; set; }
        public string? Description { get; set; }
        public int? ConsolidationStatusId { get; set; }
    }
}
