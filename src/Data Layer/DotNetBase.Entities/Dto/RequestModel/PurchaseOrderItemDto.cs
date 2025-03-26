namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreatePurchaseOrderItem
    {
        public int? PurchaseOrderId { get; set; }
        public int? SupplierQuotationItemId { get; set; }
        public int? ProductId { get; set; }
        public int OrderedQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? LineAmount { get; set; }
        public string? Description { get; set; }
    }
    public class UpdatePurchaseOrderItem
    {
        public int OrderedQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? LineAmount { get; set; }
        public string? Description { get; set; }
    }
}
