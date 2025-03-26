namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreatePurchaseOrderStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
    
    public class UpdatePurchaseOrderStatus
    {
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
}
