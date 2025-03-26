namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateSupplierQuotation
    {
        public string QuotationNumber { get; set; } = null!;
        public DateTime QuotationDate { get; set; }
        public int? RequestForQuotationId { get; set; }
        public int? SupplierCompanyId { get; set; }
        public int? QuotationStatusId { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? PaymentTerms { get; set; }
        public string? DeliveryTerms { get; set; }
        public string? Notes { get; set; }
        public int? CurrencyId { get; set; }
        public int? QuotationApprovalStatusId { get; set; }
    }
    public class UpdateSupplierQuotation
    {
        public string QuotationNumber { get; set; } = null!;
        public DateTime QuotationDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? PaymentTerms { get; set; }
        public string? DeliveryTerms { get; set; }
        public string? Notes { get; set; }
    }
}
