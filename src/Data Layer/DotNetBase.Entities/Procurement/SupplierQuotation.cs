using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class SupplierQuotation : BaseEntity, ISoftDeletable
    {
        public string QuotationNumber { get; set; }
        public DateTime QuotationDate { get; set; }
        public int RequestForQuotationId { get; set; }
        public int SupplierCompanyId { get; set; }
        public int QutationStatusId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string PaymentTerms { get; set; }
        public string DeliveryTerms { get; set; }
        public string Note { get; set; }
        public int CurrencyId { get; set; }
        public int QuotationApprovalStatusId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
