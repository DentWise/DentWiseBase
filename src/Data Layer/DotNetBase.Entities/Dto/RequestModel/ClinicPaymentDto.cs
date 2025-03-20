namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateClinicPayment
    {
        public int ClinicCompanyId { get; set; }
        public int PurchaseRequestConsolidationId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public int CurrencyId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
        public int? PrePaymentStatusId { get; set; }
    }

    public class UpdateClinicPayment
    {
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public int? CurrencyId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
        public int? PrePaymentStatusId { get; set; }
    }
}
