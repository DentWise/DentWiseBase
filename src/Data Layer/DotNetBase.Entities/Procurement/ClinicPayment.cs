using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Procurement
{
    public class ClinicPayment : BaseEntity, ISoftDeletable
    {
        public int ClinicCompanyId { get; set; }
        public int PurchaseRequestConsolidationId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public int CurrencyId { get; set; }
        public string PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; }
        public string Note { get; set; }
        public int PrePaymentStatusId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
