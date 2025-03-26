namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreatePurchaseOrder
    {
        public string PurchaseOrderNumber { get; set; } = null!;
        public DateTime PurchaseOrderDate { get; set; }
        public int? SupplierQuotationId { get; set; }
        public int? RequestForQuotationId { get; set; }
        public int? SupplierCompanyId { get; set; }
        public int? PurchaseOrderStatusId { get; set; }
        public string? Description { get; set; }
        public decimal? OrderAmount { get; set; }
        public int? CurrencyId { get; set; }
        public string? PaymentTerms { get; set; }
        public string? DeliveryTerms { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
    }
}
