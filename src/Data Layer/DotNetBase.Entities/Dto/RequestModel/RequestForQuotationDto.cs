namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateRequestForQuotation
    {
        public string Rfqnumber { get; set; } = null!;
        public DateTime Rfqdate { get; set; }
        public int? PurchaseRequestConsolidationId { get; set; }
        public int? SupplierCompanyId { get; set; }
        public int? RfqstatusId { get; set; }
        public string? Description { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? ResponseDueDate { get; set; }
    }
    public class UpdateRequestForQuotation
    {
        public string? Description { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? ResponseDueDate { get; set; }
    }
}
